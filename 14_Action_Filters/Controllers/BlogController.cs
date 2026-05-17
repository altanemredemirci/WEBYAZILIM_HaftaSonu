using _14_Action_Filters.Filters;
using _14_Action_Filters.Services;
using Microsoft.AspNetCore.Mvc;

namespace _14_Action_Filters.Controllers
{
    [ServiceFilter(typeof(LogActionFilter))]
    [ServiceFilter(typeof(PerformanceFilter))]
    public class BlogController : Controller
    {
        private readonly BlogService _blogService;
        private readonly ILogger<BlogController> _logger;

        public BlogController(BlogService blogService,ILogger<BlogController> logger)
        {
            _blogService = blogService;
            _logger = logger;
        }


        public IActionResult Index()
        {
            var posts = _blogService.GetAllPosts();

            ViewBag.FilterInfo = "Bu sayfa 3 farklı Action Filter kullanıyor: Log,Performance,Authorization";
            ViewBag.MiddlewareInfo = "Action Filter'lar sadece MVC action'larında çalışır, Middleware'ler tüm HTTP isteklerinde çalışır";

            return View(posts);
        }

        public ActionResult Details(int id)
        {
            var post = _blogService.GetPostById(id);
            if (post == null)
            {
                return NotFound();
            }
            ViewBag.FilterDemo = "Bu action'da Authorization ve Performance filterları çalıştı";

            return View(post);
        }
    }
}
