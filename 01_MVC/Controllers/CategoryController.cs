using Microsoft.AspNetCore.Mvc;

namespace _01_MVC.Controllers
{
    public class CategoryController : Controller
    {
        //Default olarak Home/Index action çalıştırılır. Farklı bir Controller altındaki actiona gitmek için /Controller/Action şeklinde yazılır.
        public IActionResult Index()
        {
            return View();
        }
    }
}
