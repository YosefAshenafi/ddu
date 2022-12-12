using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static DDU.Helper;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
namespace DDU.Controllers
{
    public class AttendanceController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _he;
        private object dateTime;

        public AttendanceController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            IEnumerable<EmployeeRegistration> objEmployeeList = _db.employeeRegistration;
            return View(objEmployeeList);
        }

    

        //Post
      
        //Get Profile
        public IActionResult Profile(Guid? id)
        {
            ViewModel mymodel = new ViewModel();
            ViewBag.Registration = _db.employeeRegistration.Find(id);
            mymodel.Attendances = _db.Attendance.Select(z => z).Where(s => s.EmployeeID == id).ToList();
            
            return View(mymodel);
        }

        //Get    
        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }

            var employeesFromDb = _db.employeeRegistration.Find(id);


            if (employeesFromDb == null)
            {
                return NotFound();

            }


            return View(employeesFromDb);
        }
        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeRegistration obj)
        {

            _db.employeeRegistration.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Edit Add successfully";
            return RedirectToAction("Index");
        }

        //Get    
        //public IActionResult Delete(Guid? id)
        //{

        //    var employeesFromDb = _db.employeeRegistration.Find(id);


        //    if (employeesFromDb == null)
        //    {
        //        return NotFound();

        //    }
        //    return View(employeesFromDb);
        //}
        //Post
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePost(Guid? id)
        //{

        //    var obj = _db.employeeRegistration.Find(id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _db.employeeRegistration.Remove(obj);
        //    _db.SaveChanges();
        //    TempData["success"] = "delete successfully";
        //    return RedirectToAction("Index");

        //}

        // GET: EmployeeEducation/AddOrEdit(Insert)
        // GET: EmployeeEducation/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(Guid id, Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                var AttendanceModel = new Attendance();
                AttendanceModel.EmployeeID = Employeeid;
                return View(AttendanceModel);
            }

            else
            {
                var AttendanceModel = _db.Attendance.Find(id);
                if (AttendanceModel == null)
                {
                    return NotFound();
                }
                return View(AttendanceModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public IActionResult AddOrEdit(Attendance obj)
        public async Task<IActionResult> AddOrEdit(Guid id, Guid Employeeid, [Bind("AttendanceID,EmployeeID,EmployeeName,Department,TimeLineType,CheckIn,Checkout,Workinghours,NetMinutes,Shift,Status,Remark,Date,SessionID,SessionIP,SessionMAC")] Attendance AttendanceModel, Attendance attendanceModel)
        { 
            if (ModelState.IsValid)
            {
                //Update
                if (AttendanceModel.AttendanceID != null)
                {
                    try
                    {

                        AttendanceModel.Checkout = DateTime.Now;
                        _db.Update(AttendanceModel);
                        await _db.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!AttendanceExists(AttendanceModel.AttendanceID))
                        { return NotFound(); }
                        else
                        { throw; }
                    }

                }
                else
                {
                    AttendanceModel.AttendanceID = Guid.NewGuid();
                    AttendanceModel.EmployeeID = Employeeid;
                    AttendanceModel.Date = DateTime.Now;
                    AttendanceModel.CheckIn = DateTime.Now;
                    _db.Attendance.Add(attendanceModel);
                    _db.SaveChanges();
                }
                TempData["success"] = "Attendance created successfully";
                //return RedirectToAction("Index");
               // return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _db.Attendance.ToList()) });
            }
            return View(attendanceModel);
            //return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _db.Lookup.ToList()) });
        }
        


        //    if (ModelState.IsValid)
        //    {

                //Update
//                if (AttendanceModel.AttendanceID != null)
//                {
//                    try
//                    {

//                        AttendanceModel.Checkout = DateTime.Now;
//                        _db.Update(AttendanceModel);
//                        await _db.SaveChangesAsync();

//    }
//                    catch (DbUpdateConcurrencyException)
//                    {
//                        if (!AttendanceExists(AttendanceModel.AttendanceID))
//                        { return NotFound();
//}
//                        else
//{ throw; }
//                    }

//                }

        //        //Insert                
        //        else
        //        {
                    
        //                AttendanceModel.AttendanceID = Guid.NewGuid();
        //                AttendanceModel.EmployeeID = Employeeid;
        //                AttendanceModel.Date = DateTime.Now;
        //                AttendanceModel.CheckIn = DateTime.Now;
        //                //AttendanceModel.Workinghours = AttendanceModel.Checkout.Subtract(AttendanceModel.CheckIn);
        //                _db.Attendance.Add(AttendanceModel);
        //                _db.SaveChanges();

                    
        //        }
        //        //return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
        //        return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _db.Attendance.ToList()) });
        //    }
        //   // return View(AttendanceModel);
        //    //return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", _db.Lookup.ToList()) });
        //}

        private bool AttendanceExists(DateTime dateTime, Guid Employeeid)
        {
            return _db.Attendance.Any(e => e.CheckIn == dateTime && e.EmployeeID == Employeeid);
        }
        private bool AttendanceExists(Guid? attendanceID)
        {
            throw new NotImplementedException();
        }


        public IActionResult Delete(Guid id, Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                return NotFound();
            }
            var AttendanceFromDb = _db.Attendance.Find(id);
            //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
            //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u => u.Id == id);

            if (AttendanceFromDb == null)
            {
                return NotFound();
            }

            return View(AttendanceFromDb);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(Guid id, Guid Employeeid)
        {
            var obj = _db.Attendance.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Attendance.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Attendance deleted successfully";
            return RedirectToAction("Index");
        //    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "_ViewAll", _db.Attendance.ToList()) });
        }

    }
}
