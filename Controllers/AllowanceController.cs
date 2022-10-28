using Dapper;
using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;
using static DDU.Helper;

namespace DDU.Controllers
{
    public class AllowanceController : Controller
    {
        private readonly ApplicationDbContext _db;
        //private string strConnectionString = "User Id=sa;Password=Ahmi#comp#1;Server=.;Database=DDUDB;";
        public AllowanceController(ApplicationDbContext db)
        {
            _db = db;           
        }
        public IActionResult Index()
        {
            IEnumerable<vw_Allowance> objAllowanceList = _db.vw_Allowance.ToList();
            return View(objAllowanceList);
        }

        //AddAllowance
        public IActionResult AddAllowance()
        {
            Allowance mymodel = new Allowance();

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
            mymodel.ListAllowanceType = new List<SelectListItem>();
            var data = _db.allowanceType.ToList();
            mymodel.ListAllowanceType.Add(new SelectListItem
            {
                Text = "Select Allowance",
                Value = ""

            });
            foreach (var item in data)
            {
                mymodel.ListAllowanceType.Add(new SelectListItem
                {
                    Text = item.AllowanceTypeName,
                    Value = Convert.ToString(item.AllowanceTypeID)

                });
            }


            return View(mymodel);
           // return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAllowanceAsync(Allowance obj)
        {
            if (obj.DepartmentName!=null)
            {
                
                    using (IDbConnection con = new SqlConnection(_db.strConnectionString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                    
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@AllowanceType", obj.AllowanceType);
                        parameters.Add("@Amount", obj.Amount);
                        parameters.Add("@EffectiveDate", obj.EffectiveDate);
                        parameters.Add("@SessionID", obj.SessionID);
                        parameters.Add("@SessionIP", obj.SessionIP);
                        parameters.Add("@SessionMAC", obj.SessionMAC);
                        parameters.Add("@departmentId", int.Parse(obj.DepartmentName.ToString()));
                        parameters.Add("@Remark","");
                    con.Execute("[dbo].[sp_InsertIntoAllowance]", parameters, commandType: CommandType.StoredProcedure);
                    }
                    return RedirectToAction("Index", "Allowance");
               
            }
            return View();

            //return View(obj);
        }

        //Get Profile
        public IActionResult AllowanceDetail(Guid? id)
        {

            IEnumerable<Allowance> pomodel = _db.allowance.Select(z => z).Where(s => s.EmployeeID == (Guid)id).OrderByDescending(s => s.EffectiveDate); 
            ViewData["Employeeid"] = (Guid)id;
            if (pomodel != null)
            {

                foreach (Allowance obj in pomodel)
                {
                    //var Depdata = _db.department.Select(z => z).Where(s => s.DepartmentID == obj.DepartmentName).ToList();
                    //var Posdata = _db.positions.Select(z => z).Where(s => s.PositionId == obj.PositionId).ToList();
                    var empdata = _db.employeeRegistration.Select(z => z).Where(s => s.EmployeeID == id).ToList();

                    //if (Depdata != null) obj.DepartmentName = Depdata[0].DepartmentName;
                    //if (Posdata != null) obj.PositionName = Posdata[0].Job_title;
                    if (empdata != null) obj.EmployeeName = String.Format("{0} {1}", empdata[0].FirstName, empdata[0].MiddleName);
                }
            }
            return View(pomodel);
        }

        // GET: Allowance/AddOrEdit(Insert)
        // GET: Allowance/AddOrEdit/5(Update)
        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(Guid id, Guid Employeeid)
        {
            if (id == Guid.Empty)
            {
                var allowanceModel = new Allowance();
                allowanceModel.EmployeeID = Employeeid;
                // ViewBag.Registration = _db.employeeRegistration.Find(id);
                //allowanceModel.ListAllowanceType = new List<SelectListItem>();
                //var data = _db.allowanceType.ToList();
                //allowanceModel.ListAllowanceType.Add(new SelectListItem
                //{
                //    Text = "Select Allowance",
                //    Value = ""

                //});
                //foreach (var item in data)
                //{
                //    allowanceModel.ListAllowanceType.Add(new SelectListItem
                //    {
                //        Text = item.AllowanceTypeName,
                //        Value = Convert.ToString(item.AllowanceTypeID)

                //    });
                //}

                return View(allowanceModel);
            }

            else
            {
                var allowanceModel = _db.allowance.Find(id);
                if (allowanceModel == null)
                {
                    return NotFound();
                }
                return View(allowanceModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit(Guid id, [Bind("AllowanceID, EmployeeID, AllowanceType, Amount, EffectiveDate, Remark, SessionID, SessionIP, SessionMAC")] Allowance allowanceModel)
        {
            if (ModelState.IsValid)
            {

                //Update
                if (allowanceModel.AllowanceID != Guid.Empty)
                {
                    try
                    {
                        _db.Update(allowanceModel);
                        await _db.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        //if (!EducationModelExists(skillModel.EmpSkillId))
                        //{ return NotFound(); }
                        //else
                        //{ 
                            throw; 
                        //}
                    }

                }
                //Insert                
                else
                {
                    try
                    {
                        allowanceModel.AllowanceID = Guid.NewGuid();
                        _db.allowance.Add(allowanceModel);
                        _db.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        throw;
                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index") });
            }
            return Json(new { isValid = false, html = Helper.RenderRazorViewToString(this, "AddOrEdit", allowanceModel) });
        }

        public IActionResult DeletePost(Guid? id)
        {

            var obj = _db.allowance.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.allowance.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "delete successfully";
            IEnumerable<Allowance> objallowanceList = _db.allowance;
            objallowanceList = _db.allowance;
            return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", objallowanceList) });

        }
    }
}
