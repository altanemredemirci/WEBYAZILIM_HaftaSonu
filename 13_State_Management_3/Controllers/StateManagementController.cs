using Microsoft.AspNetCore.Mvc;

namespace _13_State_Management_3.Controllers
{
    public class StateManagementController : Controller
    {
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("UserName", "Altan Emre Demirci");
            HttpContext.Session.SetInt32("CartCount", 5);

            return Content("Session kurulumları gerçekleştirildi.");
        }

        public IActionResult GetSession()
        {
            string userName = HttpContext.Session.GetString("UserName") ?? "Misafir";
            int cartCount = HttpContext.Session.GetInt32("CartCount") ?? 0;

            return Content($"Kullanıcı Adı:{userName} Sepette {cartCount} adet ürün vardır.");
        }

        public IActionResult SetTempData()
        {
            TempData["SuccessMessage"] = "Ürün Sepete Eklendi.";

            return RedirectToAction("ShowTempData");
        }

        public IActionResult ShowTempData()
        {
            string message = TempData["SuccessMessage"]?.ToString() ?? "Mesaj Yok";

            if(message!="Mesaj Yok")
            {
                int cartCount = HttpContext.Session.GetInt32("CartCount") ?? 0;
                cartCount++;
                HttpContext.Session.SetInt32("CartCount", cartCount);
            }

            return Content(message);
        }

        public IActionResult SetCookie()
        {
            CookieOptions options = new CookieOptions()
            {
                IsEssential = true,
                HttpOnly = true,
                Expires = DateTime.Now.AddDays(30)
            };

            HttpContext.Response.Cookies.Append("ThemePreference", "DarkMode", options);

            return Content("Tema tercihi tarayıcıya (Cookie) kaydedildi");
        }


        public IActionResult GetCookie()
        {
            string theme = HttpContext.Request.Cookies["ThemePreference"] ?? "LightMode";

            return Content($"Kullanıcının seçtiği tema:{theme}");
        }
    }
}
