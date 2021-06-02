using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TurkeyNewsExperimental.BLL.Services;

namespace TurkeyNewsExperimental.UI.Controllers
{
    public class HomeController : Controller
    {
        IArticleService _newsService;
        IConfiguration _configuration;

        public HomeController(IArticleService newsService, IConfiguration configuration)
        {
            _newsService = newsService;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {            
            ViewBag.list = _newsService.GetArticles(_configuration.GetValue<string>("ApiUri"));
            return View();
        }
    }
}
