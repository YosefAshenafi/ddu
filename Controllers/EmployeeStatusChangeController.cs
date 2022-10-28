using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DDU.Controllers
{
    
    public class EmployeeStatusChangeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EmployeeStatusChangeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable<vw_EmployeeStatusChange>? vw_EmployeeStatusChange = _db.vw_EmployeeStatusChange.ToList();

            return View(vw_EmployeeStatusChange);
        }

        [HttpGet]
        public IActionResult AddEmployeeStatusChanges()
        {


            EmployeeStatusChange mymodel = new EmployeeStatusChange();

            mymodel.ListStatus = new List<SelectListItem>();
            var datadep = _db.tblLookup.Select(z => z).Where(s => s.Parent == "1").ToList();
            mymodel.ListStatus.Add(new SelectListItem
            {
                Text = "Select Status",
                Value = ""

            });
            foreach (var item in datadep)
            {
                mymodel.ListStatus.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = Convert.ToString(item.Id)

                });
            }
            mymodel.ListEmployees = new List<SelectListItem>();
            var data = _db.employeeRegistration.ToList();
            mymodel.ListEmployees.Add(new SelectListItem
            {
                Text = "Select Employee",
                Value = ""

            });
            foreach (var item in data)
            {
                mymodel.ListEmployees.Add(new SelectListItem
                {
                    Text = String.Format("{0} {1}", item.FirstName, item.MiddleName),
                    Value = Convert.ToString(item.EmployeeID)

                });
            }


            return View(mymodel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployeeStatusChangesAsync(EmployeeStatusChange obj)
        {
            obj.EmployeeStatusChangeID = Guid.NewGuid();
            if (ModelState.IsValid)
            {
                _db.employeeStatusChange.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "EmployeeStatusChange Create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(Guid? id)
        {
            if (id == null || id == Guid.Empty)
            {
                return NotFound();
            }
            EmployeeStatusChange mymodel = new EmployeeStatusChange();

            mymodel = _db.employeeStatusChange.Find(id);

            mymodel.ListStatus = new List<SelectListItem>();
            var datadep = _db.tblLookup.Select(z => z).Where(s => s.Parent == "1").ToList();
            mymodel.ListStatus.Add(new SelectListItem
            {
                Text = "Select Status",
                Value = ""

            });
            foreach (var item in datadep)
            {
                mymodel.ListStatus.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = Convert.ToString(item.Id)

                });
            }

            mymodel.ListEmployees = new List<SelectListItem>();
            var data = _db.employeeRegistration.ToList();
            mymodel.ListEmployees.Add(new SelectListItem
            {
                Text = "Select Employee",
                Value = ""

            });
            foreach (var item in data)
            {
                mymodel.ListEmployees.Add(new SelectListItem
                {
                    Text = String.Format("{0} {1}", item.FirstName, item.MiddleName),
                    Value = Convert.ToString(item.EmployeeID)

                });
            }

            return View(mymodel);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(EmployeeStatusChange obj)
        {
            _db.employeeStatusChange.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Edit successfully";
            return RedirectToAction("Index");
        }

        // POST: Transfers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid? id)
        {
            var statusModel = await _db.employeeStatusChange.FindAsync(id);
            _db.employeeStatusChange.Remove(statusModel);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
