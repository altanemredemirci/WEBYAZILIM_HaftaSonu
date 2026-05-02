using _12_Dependency_Injection_2.Models;
using _12_Dependency_Injection_2.ProductService.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _12_Dependency_Injection_2.Controllers
{
    public class HomeController : Controller
    {

        //Injection - Enjekte etmek
        private readonly IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            Product p = new Product();
            p.Name = "Etek";
            p.Price = 1000;
            p.Stock = 100;
            _productService.Create(p);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       //Category:Id,Name,Description
    }
}
