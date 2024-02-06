using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class CategorieController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
