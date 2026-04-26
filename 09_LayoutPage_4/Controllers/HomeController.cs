using _09_LayoutPage_4.Context;
using _09_LayoutPage_4.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _09_LayoutPage_4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //slider slider = new slider();
            //slider.Title1 = "Dünyanın En İyi";
            //slider.Title2 = "Eğitim ve Öğretim Merkezi";
            //slider.Description = "2025-2026 eğitim ve öğretim yılının zirvesine sizde davetlisiniz. Size özel %40 indirim ile sizleri bekliyoruz.";
            //slider.ImageUrl = "home-img2.png";


            //Counter counter1 = new Counter();
            //counter1.Count = 134;
            //counter1.Title = "Online Kurslarımız";
            //counter1.Icon = "ti-folder";

            //Counter counter2 = new Counter();
            //counter2.Count = 299;
            //counter2.Title = "Akademik Programlar";
            //counter2.Icon = "ti-medall-alt";

            //Counter counter3 = new Counter();
            //counter3.Count = 684;
            //counter3.Title = "Sertifikalı Öğrenciler";
            //counter3.Icon = "ti-id-badge";

            //Counter counter4 = new Counter();
            //counter4.Count = 941;
            //counter4.Title = "Aktif Öğrenciler";
            //counter4.Icon = "ti-user";

            //List<Counter> counters = new List<Counter>();
            //counters.Add(counter1);
            //counters.Add(counter2);
            //counters.Add(counter3);
            //counters.Add(counter4);


            DataContext context = new DataContext();
            var slider = context.Sliders.FirstOrDefault();


            List<Counter> counters = context.Counters.ToList();

            SliderCounterViewModel viewModel = new SliderCounterViewModel();
            viewModel.Slider=slider;
            viewModel.Counters = counters;

            return View(viewModel); //View sayfasına hem slider hem de counters taşımam lazım
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
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
