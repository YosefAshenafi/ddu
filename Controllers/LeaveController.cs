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
    }
}
