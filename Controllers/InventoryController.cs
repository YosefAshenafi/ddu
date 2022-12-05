using Microsoft.AspNetCore.Mvc;

namespace DDU.Controllers
{
    public class InventoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PropertyManagement()
        {
            return View();
        }
    }
}
