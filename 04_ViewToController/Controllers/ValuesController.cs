using _04_ViewToController.Models;
using Microsoft.AspNetCore.Mvc;

namespace _04_ViewToController.Controllers
{
    public class ValuesController : Controller
    {
        //GET:View sayfası açar.
        public IActionResult UrunKayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UrunKayit(Product product)
        {
            if (ModelState.IsValid) //class da tanımlanan bütün özellikleri sağlıyor mu?
            {

            }

            return View(product);
        }

        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CategoryCreate(Category category)
        {
            if (ModelState.IsValid) //class da tanımlanan bütün özellikleri sağlıyor mu?
            {
                //ModelOnly
                //AddModelError
                //Entity ile veritabanı kayıt işlemi
            }

            return View(category);
        }
    }
}
