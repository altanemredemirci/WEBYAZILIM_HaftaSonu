using _02_RazorSyntax.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _02_RazorSyntax.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            //ViewBag: Controller'dan View'e data taşımamızı sağlar.
            ViewBag.Title = "Hakkımızda";
            ViewBag.Message = "Hoş Geldiniz";
            ViewBag.UserCount = 1200;
            ViewBag.IsLoggedIn = false;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
