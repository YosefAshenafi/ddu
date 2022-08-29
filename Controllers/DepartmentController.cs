using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DDU.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public DepartmentController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }
        public IActionResult Index()
        {
            IEnumerable<Department> alldepartment = _db.department;
            alldepartment = alldepartment.ToList().Where(e=>e.IsActive == true);
            return View(alldepartment);
        }
        public IActionResult AddDepartment()
        {
            IEnumerable<Department> alldepartment = _db.department.Where(e=>e.DepartmentID == 1);
            ViewData["Departments"] = alldepartment;
            return View();
        }
        public IActionResult EditDepartment(int departmentId)
        {
            ViewData["department"] = _db.department.Where(e => e.DepartmentID != departmentId || e.DisplayDepartmentID != departmentId).ToList();
            var department = _db.department.FirstOrDefault(d => d.DepartmentID == departmentId);
            return View(department);
        }
        [HttpPost]
        public IActionResult SaveDepartment(Department dept)
        {
            if (dept.DepartmentID == 0)
            {
                _db.department.Update(dept);
            }
            else
            {
                _db.department.Update(dept);
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteDepartment(int departmentId)
        {
            var department = _db.department.Find(departmentId);
            if (department != null)
            {
                department.IsActive = false;
                _db.department.Update(department);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
