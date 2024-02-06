using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class SalesBasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
