using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DDU.Controllers
{
    public class LeaveController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public LeaveController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }

        public IActionResult Index()
        {
            IEnumerable<TblLeaveRequest> leaveFromDb = _db.tblLeaveRequest;
            var leaveRequests = leaveFromDb.Where(e=>e.IsRemoved == 0).ToList();
            var employees = _db.employeeRegistration;
            var leaveTypes = _db.tblLeaveType.ToList().Where(e=> e.IsDeleted == 0);
            ViewData["Employees"] = employees.ToList();
            ViewData["LeaveTypes"] = leaveTypes.ToList();
            
            return View(leaveRequests);
        }

        [HttpPost]
        public IActionResult AddLeaveRequest(TblLeaveRequest request)
        {
            if (request != null)
            {
                _db.tblLeaveRequest.Add(request);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Balance()
        {
            return View();
        }

        public IActionResult Types()
        {
            IEnumerable<TblLeaveType> leaveTypes = _db.tblLeaveType;
            var allLeaveTypes = leaveTypes.ToList().Where(e => e.IsDeleted == 0);
            return View(allLeaveTypes);
        }

        [HttpPost]
        public ActionResult AddLeaveType(TblLeaveType lt)
        {
            if(lt.LeaveTypeId != 0)
            {
                _db.tblLeaveType.Update(lt);
            }
            else
            {
                _db.tblLeaveType.Add(lt);
            }
            _db.SaveChanges();
            return RedirectToAction("Types");
        }

        public IActionResult DeleteTypes(int leaveTypeId)
        {
            var leaveTypes = _db.tblLeaveType.Find(leaveTypeId);
            if(leaveTypes != null)
            {
                leaveTypes.IsDeleted = 1;
                _db.tblLeaveType.Update(leaveTypes);
                _db.SaveChanges();
            }
            return RedirectToAction("Types");
        }

        public IActionResult Approve(Guid LeaveRequestId)
        {
            var leaveRequests = _db.tblLeaveRequest;
            var approvedLeaveRequest = leaveRequests.FirstOrDefault(e => e.EmpLeaveRequestId == LeaveRequestId);
            if(approvedLeaveRequest != null)
            {
                approvedLeaveRequest.ApproveDate = DateTime.Now;
                approvedLeaveRequest.ApprovedBy = "Admin";
                _db.tblLeaveRequest.Update(approvedLeaveRequest);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
