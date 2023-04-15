using Microsoft.AspNetCore.Mvc;

namespace MVCApplication.Controllers
{
    public class BlogsController :Controller
    {
        public ActionResult Article(int id)
        {
            return View();
        }
    }
}
