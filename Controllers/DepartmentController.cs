using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;

namespace DDU.Controllers
{
    public class DepartmentController : Controller
    {
        db_a676b9_dduContext db = new db_a676b9_dduContext();
        public IActionResult Index()
        {
            var allDepartments = db.Departments.Where(e => e.IsActive == true).ToList();
            ViewData["allDepartments"] = allDepartments;
            return View();
        }
        public IActionResult AddDepartment()
        {
            ViewData["Departments"] = db.Departments.ToList();
            return View();
        }
        public IActionResult EditDepartment(int departmentId)
        {
            ViewData["Departments"] = db.Departments.Where(e => e.DepartmentId != departmentId || e.ParentDepartmentId != departmentId).ToList();
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            return View(department);
        }
        [HttpPost]
        public IActionResult SaveDepartment(Department dept)
        {
            if (dept.DepartmentId == 0)
            {
                db.Departments.Update(dept);
            }
            else
            {
                db.Departments.Update(dept);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDepartment(int departmentId)
        {
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if (department != null)
            {
                department.IsActive = false;
                db.Departments.Update(department);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
