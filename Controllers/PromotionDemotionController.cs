using DDU.Data;
using DDU.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace DDU.Controllers
{
    public class PromotionDemotionController : Controller
    {
        private readonly ApplicationDbContext _db;
        private IHostingEnvironment _he;

        public PromotionDemotionController(ApplicationDbContext db, IHostingEnvironment he)
        {
            _db = db;
            _he = he;
        }

        #region Promotion
        public IActionResult Index()
        {
            var promotionFromDb = _db.tblPromotion;
            var promotion = promotionFromDb != null ? promotionFromDb.Where(e => e.IsDeleted == 0).ToList() : null;

            var employees = _db.employeeRegistration;
            var departments = _db.department;
            ViewData["Employees"] = employees.ToList();
            ViewData["Departments"] = departments.ToList();
            
            return View(promotion);
        }

        [HttpPost]
        public IActionResult AddPromotion(TblPromotion promotion)
        {
            if (promotion != null)
            {
                _db.tblPromotion.Add(promotion);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeletePromotion(int promotionId)
        {
            var promotions = _db.tblPromotion.Find(promotionId);
            if (promotions != null)
            {
                promotions.IsDeleted = 1;
                _db.tblPromotion.Update(promotions);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        #endregion
        
        #region Demotion

        public IActionResult Demotion()
        {
            IEnumerable<TblDemotion> demotionDb = _db.tblDemotion;
            var demotions = demotionDb.Where(e => e.IsDeleted == 0).ToList();
            var employees = _db.employeeRegistration;
            ViewData["Employees"] = employees.ToList();
            return View(demotions);
        }

        [HttpPost]
        public ActionResult AddDemotion(TblDemotion demotion)
        {
            if (demotion != null)
            {
                _db.tblDemotion.Add(demotion);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDemotion(int demotionId)
        {
            var demotions = _db.tblDemotion.Find(demotionId);
            if(demotions != null)
            {
                demotions.IsDeleted = 1;
                _db.tblDemotion.Update(demotions);
                _db.SaveChanges();
            }
            return RedirectToAction("Demotion");
        }

        #endregion
    }
}
