using Microsoft.AspNetCore.Mvc;

namespace MVCApplication.Controllers
{
    public class BlogsController :Controller
    {
        private readonly ILogger<BlogsController> _logger;

        public BlogsController(ILogger<BlogsController> logger)
        {
            _logger = logger;

        }
        public ActionResult Article(int id, int count)
        {
            return View();
        }
    }
}
