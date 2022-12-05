using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Data;
using Dapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Drawing;
using Microsoft.Data.SqlClient;
namespace DDU.Controllers
{
    public class GeneratePayrollController : Controller
    {
        private readonly ApplicationDbContext _db;
        //private string strConnectionString="User Id=sa;Password=Ahmi;Server=.;Database=DDUDB;";

        public GeneratePayrollController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index(DateTime StartTime, DateTime EndTime)
        {
            if (StartTime!=EndTime)
            {
                if (!PayrollModelExists(EndTime))
                {
                    using (IDbConnection con = new SqlConnection(_db.strConnectionString))
                    {
                        if (con.State == ConnectionState.Closed)
                            con.Open();
                        var startTime = StartTime;
                        var endTime = EndTime;
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@StartTime", startTime);
                        parameters.Add("@EndTime", endTime);
                        parameters.Add("@HDate", startTime);
                        parameters.Add("@FDate", startTime.Day);
                        parameters.Add("@TDate", endTime.Day);
                        parameters.Add("@insert", 1);
                        con.Execute("[dbo].[GeneratePayroll]", parameters, commandType: CommandType.StoredProcedure);
                    }
                    TempData["success"] = "Payroll Processed Successfully.";
                    return RedirectToAction("Payroll", "Home");
                }
                else
                {
                    
                    TempData["error"] = "Payroll has been already generated";
                   
                    return View();

                }
            }
            return View();
        }
        private bool PayrollModelExists(DateTime EndTime)
        {
            return _db.payroll.Any(e => e.PayrollMonth== EndTime.Month && e.PayrollYear== EndTime.Year);
        }
    }
}
