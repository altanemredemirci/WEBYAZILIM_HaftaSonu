using _13_State_Management_2.Extensions;
using _13_State_Management_2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _13_State_Management_2.Controllers
{
    public class HomeController : Controller
    {
        private const string CartSessionKey = "ShoppingCart";
        
        //1.Ürünleri Listeleme ve Sepeti Gösterme
        public IActionResult Index()
        {
            //Session'dan sepeti oku, yoksa boş bir liste oluştur
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            return View(cart);
        }

        [HttpPost]
        public IActionResult AddToCart(int id,string name,decimal price)
        {
            //Önce mevcut sepeti Session'dan çekiyoruz
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSessionKey) ?? new List<CartItem>();

            //Ürün sepette var mı kontrolü
            var existingItem = cart.FirstOrDefault(c => c.ProductId == id);

            if (existingItem != null)
            {
                existingItem.Quantity++;
            }
            else
            {
                cart.Add(new CartItem { ProductId = id, ProductName = name, Price = price, Quantity = 1 });
            }

            //Güncel sepeti tekrar JSON olarak session'a kaydediyoruz
            HttpContext.Session.SetObjectAsJson(CartSessionKey, cart);

            //TEMPDATA Kullanımı:Sadece bir sonraki sayfada görünecek bir bildirim mesajı
            TempData["SuccessMessage"] = $"{name} başarıyla sepete eklendi";

            //İşlem bitince ürün listesine geri dön
            
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
