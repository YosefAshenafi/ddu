using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDU.Controllers
{
    public class TransferController : Controller
    {
        private readonly ApplicationDbContext _db;

        public TransferController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<vw_EmployeeTransfer> vw_transfer = _db.vw_EmployeeTransfer.ToList();
            
            return View(vw_transfer);
        }

        [HttpGet]
        public IActionResult AddTransfers()
        {
            

            EmployeeTransfer mymodel = new EmployeeTransfer();

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
            mymodel.ListPosition = new List<SelectListItem>();
            var data = _db.positions.ToList();
            mymodel.ListPosition.Add(new SelectListItem
            {
                Text = "Select Position",
                Value = ""

            });
            foreach (var item in data)
            {
                mymodel.ListPosition.Add(new SelectListItem
                {
                    Text = item.Job_title,
                    Value = Convert.ToString(item.PositionId)

                });
            }

            mymodel.ListEmployees = new List<SelectListItem>();
            var Empdata = _db.employeeRegistration.ToList();
            mymodel.ListEmployees.Add(new SelectListItem
            {
                Text = "Select Employees",
                Value = ""

            });
            foreach (var item in Empdata)
            {
                mymodel.ListEmployees.Add(new SelectListItem
                {
                    Text = String.Format("{0}{1}", item.FirstName, item.MiddleName),
                    Value = Convert.ToString(item.EmployeeID)
                }) ;
            }
            return View(mymodel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTransfersAsync(EmployeeTransfer obj)
        {
            obj.TransferID = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                _db.employeeTransfer.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Transfer Create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult EditTransfers(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            EmployeeTransfer  mymodel = new EmployeeTransfer();

            mymodel = _db.employeeTransfer.Find(id);
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
            mymodel.ListPosition = new List<SelectListItem>();
            var data = _db.positions.ToList();
            mymodel.ListPosition.Add(new SelectListItem
            {
                Text = "Select Position",
                Value = ""

            });
            foreach (var item in data)
            {
                mymodel.ListPosition.Add(new SelectListItem
                {
                    Text = item.Job_title,
                    Value = Convert.ToString(item.PositionId)

                });
            }

            mymodel.ListEmployees = new List<SelectListItem>();
            var Empdata = _db.employeeRegistration.ToList();
            mymodel.ListEmployees.Add(new SelectListItem
            {
                Text = "Select Employees",
                Value = ""

            });
            foreach (var item in Empdata)
            {
                mymodel.ListEmployees.Add(new SelectListItem
                {
                    Text = String.Format("{0}{1}", item.FirstName, item.MiddleName),
                    Value = Convert.ToString(item.EmployeeID)
                });
            }


            return View(mymodel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTransfers(EmployeeTransfer obj)
        {
            _db.employeeTransfer.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Edit successfully";
            return RedirectToAction("Index");
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var transferModel = await _db.employeeTransfer.FindAsync(id);
            _db.employeeTransfer.Remove(transferModel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get Profile
        public IActionResult EmployeeTransferDetail(Guid? id)
        {
           
            IEnumerable<EmployeeTransfer> pomodel = _db.employeeTransfer.Select(z => z).Where(s => s.EmployeeID == (Guid)id).OrderByDescending(s => s.EffectiveDate); ;

            if (pomodel != null)
            {             
                
                foreach (EmployeeTransfer obj in pomodel)
                { 
                    var Depdata = _db.department.Select(z => z).Where(s => s.DepartmentID == obj.DepartmentID).ToList();
                    var Posdata = _db.positions.Select(z => z).Where(s => s.PositionId == obj.PositionId).ToList();
                   var empdata = _db.employeeRegistration.Select(z => z).Where(s => s.EmployeeID == id).ToList();
                    
                    if (Depdata != null) obj.DepartmentName = Depdata[0].DepartmentName;
                    if (Posdata != null) obj.PositionName = Posdata[0].Job_title;
                    if (empdata != null) obj.EmployeeName = String.Format("{0} {1}", empdata[0].FirstName, empdata[0].MiddleName);
                }
            }
            return View(pomodel);
        }
    }
}
