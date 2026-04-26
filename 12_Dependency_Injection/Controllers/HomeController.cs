using _12_Dependency_Injection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependency_Injection.Controllers
{
    public class HomeController : Controller
    {
        /* Dependency Injection - Bağımlılık Yönetimi
         
        Interface olarak tanımlanan Service yapılarının database yapılarına olan bağımlılıkları yönetilir.

        Student classının temel metotları vardır. Insert,Update,Delete,List,Find,List(Expression)

         */
        public IActionResult Index()
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
