using Microsoft.AspNetCore.Mvc;
using MVCApplication.Models;
using System.Diagnostics;

namespace MVCApplication.Controllers
{
    [TypeFilter(typeof(OutageAuthFilter))]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("hello hello");
            return View();
        }

        [HttpGet]
        [Route("/contact-us")]
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        [Route("/contact-us", Name = "Contact form")]
        public IActionResult Contact([FromForm] Contact info)
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }


    
}