using Dapper;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static DDU.Helper;
using System.Data;

using DDU.Data;




namespace DDU.Controllers
{

    public class EmployeeShiftController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string strConnectionString = "User Id=sa;Password=Ahmi#comp#1;Server=.;Database=DDUDB;";
        public EmployeeShiftController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<EmployeeShift> objEmployeeShiftList = _db.employeeShift;
            return View(objEmployeeShiftList);
        }

        //AddEmployeeShift
        public IActionResult AddEmployeeShift()
        {
            EmployeeShift mymodel = new EmployeeShift();

            mymodel.ListDepartment = new List<SelectListItem>();
            var datadep = _db.department.ToList();
            mymodel.ListDepartment.Add(new SelectListItem
            {
                Text = "Select Department",
                Value = ""

            });
            foreach (var item in datadep)
            {
                mymodel.ListDepartment.Add(new SelectListItem
                {
                    Text = item.DepartmentName,
                    Value = Convert.ToString(item.DepartmentID)

                });
            }
            //mymodel.ListEmployeeShiftType = new List<SelectListItem>();
            //var data = _db.EmployeeShiftType.ToList();
            //mymodel.ListEmployeeShiftType.Add(new SelectListItem
            //{
            //    Text = "Select EmployeeShift",
            //    Value = ""

            //});
            //foreach (var item in data)
            //{
            //    mymodel.ListEmployeeShiftType.Add(new SelectListItem
            //    {
            //        Text = item.EmployeeShiftTypeName,
            //        Value = Convert.ToString(item.EmployeeShiftTypeID)

            //    });
            //}


            return View(mymodel);
            // return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployeeShiftAsync(EmployeeShift obj)
        {
            if (obj.DepartmentName != null)
            {

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    //parameters.Add("@EmployeeShiftType", obj.EmployeeShiftType);
                    //parameters.Add("@Amount", obj.Amount);
                    //parameters.Add("@EffectiveDate", obj.EffectiveDate);
                    parameters.Add("@SessionID", obj.SessionID);
                    parameters.Add("@SessionIP", obj.SessionIP);
                    parameters.Add("@SessionMAC", obj.SessionMAC);
                    parameters.Add("@departmentId", int.Parse(obj.DepartmentName.ToString()));
                    parameters.Add("@Remark", "");
                    con.Execute("[dbo].[sp_InsertIntoEmployeeShift]", parameters, commandType: CommandType.StoredProcedure);
                }
                return RedirectToAction("Index", "EmployeeShift");

            }
            return View();

            //return View(obj);
        }

        //Get Profile
        public IActionResult EmployeeShiftDetail(Guid? id)
        {

            IEnumerable<EmployeeShift> pomodel = _db.employeeShift.Select(z => z).Where(s => s.EmployeeID == (Guid)id).OrderByDescending(s => s.FromDate);
            ViewData["Employeeid"] = (Guid)id;
            if (pomodel != null)
            {

                foreach (EmployeeShift obj in pomodel)
                {
                    //var Depdata = _db.department.Select(z => z).Where(s => s.DepartmentID == obj.DepartmentName).ToList();
                    //var Posdata = _db.positions.Select(z => z).Where(s => s.PositionId == obj.PositionId).ToList();
                    var empdata = _db.employeeRegistration.Select(z => z).Where(s => s.EmployeeID == id).ToList();

                    //if (Depdata != null) obj.DepartmentName = Depdata[0].DepartmentName;
                    //if (Posdata != null) obj.PositionName = Posdata[0].Job_title;
                    if (empdata != null) obj.EmployeeName = String.Format("{0} {1}", empdata[0].FirstName, empdata[0].MiddleName);
                }
            }
            return View(pomodel);
        }

        // GET: EmployeeShift/AddOrEdit(Insert)
        // GET: EmployeeShift/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(Guid id, Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                var EmployeeShiftModel = new EmployeeShift();
                EmployeeShiftModel.EmployeeID = Employeeid;
                // ViewBag.Registration = _db.employeeRegistration.Find(id);
                //EmployeeShiftModel.ListEmployeeShiftType = new List<SelectListItem>();
                //var data = _db.EmployeeShiftType.ToList();
                //EmployeeShiftModel.ListEmployeeShiftType.Add(new SelectListItem
                //{
                //    Text = "Select EmployeeShift",
                //    Value = ""

                //});
                //foreach (var item in data)
                //{
                //    EmployeeShiftModel.ListEmployeeShiftType.Add(new SelectListItem
                //    {
                //        Text = item.EmployeeShiftTypeName,
                //        Value = Convert.ToString(item.EmployeeShiftTypeID)

                //    });
                //}

                return View(EmployeeShiftModel);
            }

            else
            {
                var EmployeeShiftModel = _db.employeeShift.Find(id);
                if (EmployeeShiftModel == null)
                {
                    return NotFound();
                }
                return View(EmployeeShiftModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Guid id, [Bind("EmployeeShiftID, EmployeeID, EmployeeShiftType, Amount, EffectiveDate, Remark, SessionID, SessionIP, SessionMAC")] EmployeeShift EmployeeShiftModel)
        {
            if (ModelState.IsValid)
            {

                //Update
                if (EmployeeShiftModel.EmployeeShiftID != Guid.Empty)
                {
                    try
                    {
                        _db.Update(EmployeeShiftModel);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        //if (!EducationModelExists(skillModel.EmpSkillId))
                        //{ return NotFound(); }
                        //else
                        //{ 
                        throw;
                        //}
                    }

                }
                //Insert                
                else
                {
                    try
                    {
                        EmployeeShiftModel.EmployeeShiftID = Guid.NewGuid();
                        _db.employeeShift.Add(EmployeeShiftModel);
                        _db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", EmployeeShiftModel) });
        }

        public IActionResult DeletePost(Guid? id)
        {

            var obj = _db.employeeShift.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.employeeShift.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "delete successfully";
            IEnumerable<EmployeeShift> objEmployeeShiftList = _db.employeeShift;
            objEmployeeShiftList = _db.employeeShift;
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", objEmployeeShiftList) });

        }
    }
}

