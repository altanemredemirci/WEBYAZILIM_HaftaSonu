using _03_ControllerToView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _03_ControllerToView.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Product p = new Product();
            p.Id = 1;
            p.Name = "Elma";
            p.Price = 100000.50m;
            p.Stock = 100;
            p.ImageUrl = "Nokia.webp";

            return View(p);
        }

       //Ogrenci:Ad,Soyad,Numara
    }
}
