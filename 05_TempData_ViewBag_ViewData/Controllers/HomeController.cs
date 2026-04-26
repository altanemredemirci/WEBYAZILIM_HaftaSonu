using _05_TempData_ViewBag_ViewData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _05_TempData_ViewBag_ViewData.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //Controller dan View'e data taşımanın 3 farklı yolu vardır.
            /*
             1-ViewData:Kendisine verilen anahtar kelimeyle bir değeri yönlendirildiği sayfaya 1 seferlik taşır.
             2-ViewBag:Kendisine verilen anahtar kelimeyle bir değeri yönlendirildiği sayfaya 1 seferlik taşır.
             3-TempData:Bir sefere mahsus sayfadan sayfaya yönlendirilebilir data taşır.
             
             */
            ViewData["Message"] = "Altan Emre Demirci";
            ViewBag.Mesaj = "Bu ViewBag değer işlemidir.";
            TempData["Mesaj"] = "Sayfadan sayfaya transferi yapılabilir.";

            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
