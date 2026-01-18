using LetsFest.Data;
using LetsFest.Mysql;
using LetsFest.Web.Data;
using LetsFest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LetsFest.Web.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext dataContext;
        public HomeController(ApplicationDbContext _context)
        {
            dataContext = _context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public ActionResult CheckRoles()
        {
           
            return View(dataContext.EventRoles.ToList());
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
