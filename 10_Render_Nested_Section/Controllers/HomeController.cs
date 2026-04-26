using _10_Render_Nested_Section.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _10_Render_Nested_Section.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }     
    }
}
