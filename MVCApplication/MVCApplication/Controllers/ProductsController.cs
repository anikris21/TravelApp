using Microsoft.AspNetCore.Mvc;

namespace MVCApplication.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
