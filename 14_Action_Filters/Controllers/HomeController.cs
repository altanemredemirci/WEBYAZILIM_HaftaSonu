using _14_Action_Filters.Models;
using _14_Action_Filters.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _14_Action_Filters.Controllers
{
    public class HomeController : Controller
    {
        private readonly BlogService _blogService;
        //private readonly ILogger _logger;

        public HomeController(BlogService blogService)
        {
            _blogService = blogService;
            //_logger = logger;
        }

        public IActionResult Index()
        {
            var posts = _blogService.GetAllPosts();
            
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
