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
            IEnumerable<EmployeeTransfer> objEmployeeTransferList = _db.employeeTransfer;
            foreach (var objitem in objEmployeeTransferList)
            {
                var depData = _db.department.Find(objitem.DepartmentID);
                if (depData != null) objitem.DepartmentName = depData.DepartmentName;
                var PosData = _db.positions.Find(objitem.PositionId);
                if (PosData != null) objitem.PositionName = PosData.Job_title;
                var EmployeeData = _db.employeeRegistration.Find(objitem.EmployeeID);
                if (EmployeeData != null) objitem.EmployeeName = String.Format("{0}{1}", EmployeeData.FirstName,EmployeeData.MiddleName);
            }
            return View(objEmployeeTransferList);
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
    }
}
