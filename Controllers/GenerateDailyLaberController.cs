using Dapper;
using DDU.Core;
using DDU.Data;
using DDU.Models;
using DDU.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net;
using static DDU.Core.Constants;

namespace DDU.Controllers
{
    public class GenerateDailyLaberController : Controller
    {
        private readonly ApplicationDbContext _db;
        //private string strConnectionString = "User Id=sa;Password=Ahmi#comp#1;Server=.;Database=DDUDB;";

        public GenerateDailyLaberController(ApplicationDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = $"{Constants.Roles.Administrator}" + "," + $"{Constants.Roles.Manager}" + "," + $"{Constants.Roles.User}")]
        public IActionResult Index()
        {

            ViewDailyLabourer mymodel = new ViewDailyLabourer();
            mymodel.Checked = _db.dailyLabourer.Select(z => z).Where(s => s.IsPaid == false && s.IsApproved== false).ToList();
            mymodel.Approved = _db.dailyLabourer.Select(z => z).Where(s => s.IsApproved == false).ToList();
            mymodel.Paid = _db.dailyLabourer.Select(z => z).Where(s => s.IsPaid == false && s.IsApproved == true).ToList();
            return View(mymodel);
            //IEnumerable<DailyLabourer> dailyLabourer = _db.dailyLabourer.ToList();
            //return View(dailyLabourer);

        }

        [HttpGet]
        public IActionResult AddDailyLabourer()
        {            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddDailyLabourer(String IdNos, DailyLabourer appModel)
        {
            if (appModel.FromDate != appModel.ToDate)
            {

                using (IDbConnection con = new SqlConnection(_db.strConnectionString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    var startTime = appModel.FromDate;
                    var endTime = appModel.ToDate;
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@StartTime", startTime);
                    parameters.Add("@EndTime", endTime);
                    parameters.Add("@IdNos", IdNos);
                    parameters.Add("@insert", 1);
                    con.Execute("[dbo].[GenerateDailyLaber]", parameters, commandType: CommandType.StoredProcedure);
                }
                TempData["success"] = "Daily Labourer Processed Successfully.";
                return RedirectToAction("Index", "GenerateDailyLaber");
            }
            else
            {
                TempData["error"] = "Daily Labourer has not been generate";
                return View();
            }
        }

        public JsonResult Approved(Guid id, int check)
        {

            var dailyLabourer = new DailyLabourer() { DailyPayID = id, IsApproved = Convert.ToBoolean(check) };
            _db.dailyLabourer.Attach(dailyLabourer).Property(x => x.IsApproved).IsModified = true;
            _db.SaveChanges();   



            List<DailyLabourer> listDaily = new List<DailyLabourer>();
           
           
            return Json(listDaily.Count());
        }
        public JsonResult Paid(Guid id, int check)
        {

            

            var dailyLabourer = new DailyLabourer() { DailyPayID = id, IsPaid = Convert.ToBoolean(check) };
            _db.dailyLabourer.Attach(dailyLabourer).Property(x => x.IsPaid).IsModified = true;
            _db.SaveChanges();
            List<DailyLabourer> listDaily = new List<DailyLabourer>();
            return Json(listDaily.Count());
        }
    }
}
