using DDU.Data;
using DDU.Models;
using DDU.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using static DDU.Helper;


namespace DDU.Controllers
{
    public class PerDiemController : Controller
    {
        private readonly ApplicationDbContext _db;
        public PerDiemController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<PerDiemViewModel> objallperdiem = new List<PerDiemViewModel>();
            objallperdiem = HttpContext.Session.Get<List<PerDiemViewModel>>("AllPerDiem");
            
            IEnumerable<PerDiemRequest> objPerDiemList = _db.PerDiemRequest;
            if (objallperdiem==null)
            {
                objallperdiem = new List<PerDiemViewModel>();
                foreach (var objPerDiem in objPerDiemList)
                {
                    PerDiemViewModel mymodel = new PerDiemViewModel();
                    var depData = _db.department.Find(objPerDiem.DepartmentID);
                    if (depData != null) objPerDiem.DepartmentName = depData.DepartmentName;
                    var EmpData = _db.employeeRegistration.Find(objPerDiem.EmployeeID);
                    if (EmpData != null) objPerDiem.EmployeeName = String.Format("{0} {1}", EmpData.FirstName, EmpData.MiddleName);
                    mymodel.Title = objPerDiem.Title;
                    mymodel.IsCheckAndConfirm = false;
                    mymodel.RequestPerDimId = objPerDiem.RequestPerDimId;
                    mymodel.SessionId = objPerDiem.SessionId;
                    mymodel.SessionIp = objPerDiem.SessionIp;
                    mymodel.SessionMac = objPerDiem.SessionMac;
                    mymodel.ApprovedBy = "";
                    mymodel.CheckAndConfirmBy = "";
                    mymodel.StartDate = objPerDiem.StartDate;
                    mymodel.EndDate = objPerDiem.EndDate;
                    mymodel.TravelPerDiem = objPerDiem.TravelPerDiem;
                    mymodel.HotelPerDiem = objPerDiem.HotelPerDiem;
                    var dataCheck = _db.perDiemCheckAndConfirm.Select(z => z).Where(s => s.RequestPerDimId == objPerDiem.RequestPerDimId).ToList();
                    if (dataCheck.Count() != 0)
                    {
                        mymodel.IsCheckAndConfirm = true;
                        var dataApprove = _db.perDiemApprove.Select(z => z).Where(s => s.CheckandconfirmId == dataCheck[0].CheckandconfirmId).ToList();
                        if (dataCheck.Count() != 0)
                        { 
                            mymodel.IsCheckAndConfirm = true;
                            mymodel.CheckandconfirmId = dataCheck[0].CheckandconfirmId;
                        }
                        if (dataApprove.Count() != 0)
                        {
                            mymodel.IsApproved = true;
                            mymodel.ApprovedId = dataApprove[0].ApprovedId;

                            if(dataApprove[0].IsPaid==true)
                            {
                                mymodel.IsPaid = true;
                            }
                        }
                    }                  
                    objallperdiem.Add(mymodel);
                }
                HttpContext.Session.Set("AllPerDiem", objallperdiem);
                return View(objPerDiemList);
            }
            else
            {
                foreach (var objPerDiem in objPerDiemList)
                {
                    var depData = _db.department.Find(objPerDiem.DepartmentID);
                    if (depData != null) objPerDiem.DepartmentName = depData.DepartmentName;
                    var EmpData = _db.employeeRegistration.Find(objPerDiem.EmployeeID);
                    if (EmpData != null) objPerDiem.EmployeeName = String.Format("{0} {1}", EmpData.FirstName, EmpData.MiddleName);
                }
                return View(objPerDiemList);
            }           

        }

        public IActionResult CheckAndConfirm()
        {
            return View();
        }

        public IActionResult PerDimApprove()
        {

            return View();
        }

        [HttpGet]
        public IActionResult AddRequestPerDim()
        {

            PerDiemRequest mymodel = new PerDiemRequest();

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
                    Text =String.Format("{0} {1}", item.FirstName, item.MiddleName),
                    Value = Convert.ToString(item.EmployeeID)

                });
            }
            return View(mymodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRequestPerDim(Guid id, [Bind("RequestPerDimID, Title, DepartmentID, EmployeeID, StartDate, EndDate, HotelPerDiem, TravelPerDiem, SessionID, SessionIP, SessionMAC")] PerDiemRequest appModel)
        {
           

            if (ModelState.IsValid)
            {

                //Update
                if (appModel.RequestPerDimId != Guid.Empty)
                {
                    try
                    {
                        _db.Update(appModel);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }

                }
                //Insert                
                else
                {               

                    appModel.RequestPerDimId = Guid.NewGuid();
                    _db.PerDiemRequest.Add(appModel);
                    _db.SaveChanges();
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddRequestPerDim", appModel) });
        }

        public JsonResult Confirmandchecked(Guid id,int check)
        {
           
            List<PerDiemViewModel> allperDiem = new List<PerDiemViewModel>();

            if (allperDiem == null)
            {

                allperDiem = new List<PerDiemViewModel>();
            }
            else
            {
                allperDiem = HttpContext.Session.Get<List<PerDiemViewModel>>("AllPerDiem");
            }

            if (allperDiem == null)
            {

                allperDiem = new List<PerDiemViewModel>();
            }
            else
            {
                foreach(var item in allperDiem)
                {
                 
                    if (item.RequestPerDimId==id && check==1)
                    { 
                        item.IsCheckAndConfirm = true;
                        PerDiemCheckAndConfirm checkModel = new PerDiemCheckAndConfirm();
                        checkModel.RequestPerDimId = item.RequestPerDimId;
                        checkModel.CheckandconfirmId = Guid.NewGuid();
                        checkModel.StartDate = item.StartDate;
                        checkModel.EndDate = item.EndDate;
                        checkModel.CheckAndConfirmBy = "Abebe Kebede";
                        checkModel.IsCheckAndConfirm = true;
                        checkModel.HotelPerDiem=item.HotelPerDiem;
                        checkModel.DepartmentId = item.DepartmentID;
                        checkModel.EmployeeId = item.EmployeeID;
                        checkModel.SessionId=item.SessionId;
                        checkModel.SessionIp=item.SessionIp;
                        checkModel.SessionMac=item.SessionMac;
                        checkModel.Title = item.Title;
                        checkModel.TravelPerDiem = item.TravelPerDiem;
                        _db.perDiemCheckAndConfirm.Add(checkModel);
                        _db.SaveChanges();
                    }                   
                   
                }
               
            }            
            HttpContext.Session.Set("AllPerDiem", allperDiem);
            return Json(allperDiem.Count());
        }

        public JsonResult Approved(Guid id, int check)
        {

            List<PerDiemViewModel> allperDiem = new List<PerDiemViewModel>();

            if (allperDiem == null)
            {

                allperDiem = new List<PerDiemViewModel>();
            }
            else
            {
                allperDiem = HttpContext.Session.Get<List<PerDiemViewModel>>("AllPerDiem");
            }

            if (allperDiem == null)
            {

                allperDiem = new List<PerDiemViewModel>();
            }
            else
            {
                foreach (var item in allperDiem)
                {

                    if (item.CheckandconfirmId == id && check == 1)
                    {
                        item.IsApproved = true;
                        PerDiemApprove ApprovedModel = new PerDiemApprove();
                        ApprovedModel.CheckandconfirmId = item.CheckandconfirmId;
                        ApprovedModel.ApprovedId = Guid.NewGuid();
                        ApprovedModel.StartDate = item.StartDate;
                        ApprovedModel.EndDate = item.EndDate;
                        ApprovedModel.ApprovedBy = "Abebe Kebede";
                        ApprovedModel.IsApproved = true;
                        ApprovedModel.HotelPerDiem = item.HotelPerDiem;
                        ApprovedModel.DepartmentId = item.DepartmentID;
                        ApprovedModel.EmployeeId = item.EmployeeID;
                        ApprovedModel.SessionId = item.SessionId;
                        ApprovedModel.SessionIp = item.SessionIp;
                        ApprovedModel.SessionMac = item.SessionMac;
                        ApprovedModel.Title = item.Title;
                        ApprovedModel.TravelPerDiem = item.TravelPerDiem;
                        _db.perDiemApprove.Add(ApprovedModel);
                        _db.SaveChanges();
                    }

                }

            }
            HttpContext.Session.Set("AllPerDiem", allperDiem);
            return Json(allperDiem.Count());
        }
        public JsonResult Paid(Guid id, int check)
        {

            List<PerDiemViewModel> allperDiem = new List<PerDiemViewModel>();

            if (allperDiem == null)
            {

                allperDiem = new List<PerDiemViewModel>();
            }
            else
            {
                allperDiem = HttpContext.Session.Get<List<PerDiemViewModel>>("AllPerDiem");
            }

            if (allperDiem == null)
            {

                allperDiem = new List<PerDiemViewModel>();
            }
            else
            {
                foreach (var item in allperDiem)
                {

                    if (item.ApprovedId == id && check == 1)
                    {
                        item.IsApproved = true;
                        PerDiemApprove ApprovedModel = new PerDiemApprove();
                        ApprovedModel.CheckandconfirmId = item.CheckandconfirmId;
                        ApprovedModel.ApprovedId = item.ApprovedId;
                        ApprovedModel.StartDate = item.StartDate;
                        ApprovedModel.EndDate = item.EndDate;
                        ApprovedModel.ApprovedBy = "Abebe Kebede";
                        ApprovedModel.IsApproved = true;
                        ApprovedModel.HotelPerDiem = item.HotelPerDiem;
                        ApprovedModel.DepartmentId = item.DepartmentID;
                        ApprovedModel.EmployeeId = item.EmployeeID;
                        ApprovedModel.SessionId = item.SessionId;
                        ApprovedModel.SessionIp = item.SessionIp;
                        ApprovedModel.SessionMac = item.SessionMac;
                        ApprovedModel.Title = item.Title;
                        ApprovedModel.TravelPerDiem = item.TravelPerDiem;
                        ApprovedModel.IsPaid = true;                  

                        _db.Update(ApprovedModel);
                        _db.SaveChangesAsync();
                    }

                }

            }
            HttpContext.Session.Set("AllPerDiem", allperDiem);
            return Json(allperDiem.Count());
        }
        


    }
}
