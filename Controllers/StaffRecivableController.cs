using Dapper;
using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using static DDU.Helper;

namespace DDU.Controllers
{
    public class StaffRecivableController : Controller
    {
        private readonly ApplicationDbContext _db;
        private string strConnectionString = "User Id=sa;Password=Ahmi#comp#1;Server=.;Database=DDUDB;";
        public StaffRecivableController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<vw_StaffRecivable> vw_staff = _db.vw_StaffRecivable.ToList();
            return View(vw_staff);
        }

        //AddStaffRecivable
        public IActionResult AddStaffRecivables()
        {
            StaffRecivable mymodel = new StaffRecivable();

           
            mymodel.ListStaffRecivableType = new List<SelectListItem>();
            var data = _db.tblLookup.Select(z => z).Where(s => s.Parent == "1002").ToList(); ;
            mymodel.ListStaffRecivableType.Add(new SelectListItem
            {
                Text = "Select StaffRecivable",
                Value = ""

            });
            foreach (var item in data)
            {
                mymodel.ListStaffRecivableType.Add(new SelectListItem
                {
                    Text = item.Description,
                    Value = Convert.ToString(item.Id)

                });
            }


            return View(mymodel);
            // return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddStaffRecivablesAsync(StaffRecivable obj)
        {
            if (obj.IdNos != null)
            {

                using (IDbConnection con = new SqlConnection(strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StaffRecivableType", obj.StaffRecivableType);
                    parameters.Add("@Amount", obj.Amount);
                    parameters.Add("@FromMonth", obj.FromMonth);
                    parameters.Add("@ToMonth ", obj.ToMonth);
                    parameters.Add("@ReturnYear ", obj.ReturnYear);
                    parameters.Add("@SessionID", obj.SessionID);
                    parameters.Add("@SessionIP", obj.SessionIP);
                    parameters.Add("@SessionMAC", obj.SessionMAC);
                    parameters.Add("@IdNos", obj.IdNos.ToString());
                    parameters.Add("@Remark", "");
                    con.Execute("[dbo].[sp_InsertIntoStaffRecivable]", parameters, commandType: CommandType.StoredProcedure);
                }
                return RedirectToAction("Index", "StaffRecivable");

            }
            return View();
        }

        //Get Profile
        public IActionResult StaffDetail(Guid? id)
        {

            IEnumerable<StaffRecivable> pomodel = _db.staffRecivable.Select(z => z).Where(s => s.EmployeeID == (Guid)id).OrderByDescending(s => s.ToMonth);
            ViewData["Employeeid"] = (Guid)id;
            if (pomodel != null)
            {

                foreach (StaffRecivable obj in pomodel)
                {

                    var empdata = _db.employeeRegistration.Select(z => z).Where(s => s.EmployeeID == id).ToList();

                    if (empdata != null) obj.EmployeeName = String.Format("{0} {1}", empdata[0].FirstName, empdata[0].MiddleName);
                    var lookupData = _db.tblLookup.Select(z => z).Where(s => s.Id == obj.StaffRecivableType).ToList();
                    if (lookupData != null) obj.staffRecivableTypeName = lookupData[0].Description;
                }
                
            }
            return View(pomodel);
        }

        // GET: StaffRecivable/AddOrEdit(Insert)
        // GET: StaffRecivable/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(Guid id, Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                var StaffRecivableModel = new StaffRecivable();
                StaffRecivableModel.EmployeeID = Employeeid;
                StaffRecivableModel.ListStaffRecivableType = new List<SelectListItem>();
                var data = _db.tblLookup.Select(z => z).Where(s => s.Parent == "1002").ToList(); ;
                StaffRecivableModel.ListStaffRecivableType.Add(new SelectListItem
                {
                    Text = "Select StaffRecivable",
                    Value = ""

                });
                foreach (var item in data)
                {
                    StaffRecivableModel.ListStaffRecivableType.Add(new SelectListItem
                    {
                        Text = item.Description,
                        Value = Convert.ToString(item.Id)

                    });
                }

                return View(StaffRecivableModel);
            }

            else
            {
                var StaffRecivableModel = _db.staffRecivable.Find(id);
                if (StaffRecivableModel == null)
                {
                    return NotFound();
                }
                return View(StaffRecivableModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Guid id, StaffRecivable StaffRecivableModel)
        {
            if (ModelState.IsValid)
            {

                //Update
                if (StaffRecivableModel.StaffRecivableID != Guid.Empty)
                {
                    try
                    {
                        _db.Update(StaffRecivableModel);
                        await _db.SaveChangesAsync();
                        TempData["success"] = "Update successfully";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                   
                        throw;                     
                    }

                }
                //Insert                
                else
                {
                    try
                    {
                        StaffRecivableModel.StaffRecivableID = Guid.NewGuid();
                        _db.staffRecivable.Add(StaffRecivableModel);
                        _db.SaveChanges();
                        TempData["success"] = "create successfully";
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", StaffRecivableModel) });
        }

        public IActionResult DeletePost(Guid? id)
        {

            var obj = _db.staffRecivable.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.staffRecivable.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "delete successfully";
            IEnumerable<StaffRecivable> objStaffRecivableList = _db.staffRecivable;
            objStaffRecivableList = _db.staffRecivable;
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", objStaffRecivableList) });

        }
    }
}
