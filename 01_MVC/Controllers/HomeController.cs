using Microsoft.AspNetCore.Mvc;

namespace _01_MVC.Controllers
{
    public class HomeController : Controller //Inheritance-Kalıtım
    {
        //IActionResult => bir web sayfası döndürülecektir.
        //Her IActionResult bir View sayfasını ayağa kaldırır.
        //Her Controller için Views klasörü altında bir controller adıyla klasör açılır.
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
    }
}
