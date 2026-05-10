using _13_State_Management.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management.Controllers
{
    public class HomeController : Controller
    {

        //Session,Cookie
        //Session state kullanıcının oturum süresince verilerini saklamımızı sağlar. Oturum sona erdiğinde bu veriler silinir.,
        //Session state özellikle kullanıcının bilgilerini saklaması gerektiğinde kullanılır.Fakat şifre, kredi kartı gibi bilgiler saklanmamalıdır.


        public IActionResult Index()
        {
            //HttpContext.Session.SetString("UserName", "Altan Emre");

            //Session'dan Veri okuma
            //var sessionUserName = HttpContext.Session.GetString("UserName");

            //Cookie state sunucu tarafında değil, kullanıcı(client,tarayıcı) tarafında saklanır.Kullanıcı tarayıcısını kapatıp açsa bile cookiler geçerlilik süresi boyunca saklanır.

            //Cookie Oluşturma
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddMinutes(30),
                HttpOnly = true,
                IsEssential = true
            };

            //Set Cookie
            //Response.Cookies.Append("UserName", "Altan Emre", cookieOptions);

            //var cookieUserName = Request.Cookies["UserName"];

            //ViewBag.SessionUserName=sessionUserName;
            //ViewBag.CookieUserName=cookieUserName;

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
