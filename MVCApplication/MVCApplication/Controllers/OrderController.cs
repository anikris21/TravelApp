using Microsoft.AspNetCore.Mvc;

namespace MVCApplication.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index(List<Order> order)
        {
            return Content("Binding success");
        }
    }

    public class Order
    {
        public string? ProductName { get; set; }
        public string? Count { get; set; }
        public string? ProductDescription { get; set;}
    }
}
