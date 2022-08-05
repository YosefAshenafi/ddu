using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DDU.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

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
            return View();
        }
        public IActionResult AddDepartment() { return View(); }
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}