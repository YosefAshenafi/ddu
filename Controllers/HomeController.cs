using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DDU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        db_a676b9_dduContext db = new db_a676b9_dduContext();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult CheckLogin(string username, string password)
        {
            if(username == null || password == null)
            {
                ViewData["Message"] = "Please fill username and password please.";
                return RedirectToAction("Login");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Employees()
        {
            return View();
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Departments()
        {
            var allDepartments = db.Departments.Where(e=>e.IsActive == true).ToList();
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
            ViewData["Departments"] = db.Departments.Where(e=>e.DepartmentId != departmentId || e.ParentDepartmentId != departmentId).ToList();
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            return View(department); 
        }
        [HttpPost]
        public IActionResult SaveDepartment(Department dept)
        {
            if(dept.DepartmentId == 0)
            {
                db.Departments.Update(dept);
            }
            else
            {
                db.Departments.Update(dept);
            }
            db.SaveChanges();
            return RedirectToAction("Departments");
        }
        public IActionResult DeleteDepartment(int departmentId)
        {
            var department = db.Departments.FirstOrDefault(d => d.DepartmentId == departmentId);
            if(department != null)
            {
                department.IsActive = false;
                db.Departments.Update(department);
                db.SaveChanges();
            }
            return RedirectToAction("Departments");
        }
        public IActionResult Attendance()
        {
            return View();
        }
        public IActionResult IndividualAttendance()
        {
            return View();
        }
        public IActionResult AllLeave()
        {
            return View();
        }
        public IActionResult LeaveBalance()
        {
            return View();
        }
        public IActionResult Jobs()
        {
            return View();
        }
        public IActionResult JobApplicants()
        {
            return View();
        }
        public IActionResult Payroll()
        {
            return View();
        }
        public IActionResult PaySlip()
        {
            return View();
        }
        public IActionResult Training()
        {
            return View();
        }
        public IActionResult PerDiem()
        {
            return View();
        }
        public IActionResult PromotionDemotion()
        {
            return View();
        }
        public IActionResult Transfer()
        {
            return View();
        }
        public IActionResult TerminationRehire()
        {
            return View();
        }
        public IActionResult LeaveTypes()
        {
            return View();
        }
        public IActionResult PropertyManagement()
        {
            return View();
        }
        public IActionResult InventoryManagement()
        {
            return View();
        }
        public IActionResult Administration()
        {
            return View();
        }
        public IActionResult ProcurementLifeCycle()
        {
            return View();
        }
        public IActionResult BidRequest()
        {
            return View();
        }
        public IActionResult BidAnnouncement()
        {
            return View();
        }
        public IActionResult BidApproval()
        {
            return View();
        }
        public IActionResult BidFollowUp()
        {
            return View();
        }
        public IActionResult InventoryConfirmation()
        {
            return View();
        }
        public IActionResult Attachments()
        {
            return View();
        }
        public IActionResult Documents()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}