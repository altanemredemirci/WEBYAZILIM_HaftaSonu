using _04_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _04_ViewToController.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //İki farklı method çeşiti vardır.
        //1.GET method: View sayfasını ekrana getirir.
        //2.POST method: View sayfasından controller a data taşınmasını sağlar.
        //Tanımlamazsanız bütün IActionResult default GET olur.
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email,string fullname)
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        //public IActionResult Register(string name,string surname,string username,string password) //overload:metot imzası:parametre sayısı,parametre veri tipi
        public IActionResult Register(User user)
        {
            return View();
        }
    }
}
