using Microsoft.AspNetCore.Mvc;

namespace Exercice02Marmosets.Controllers
{
    public class MarmosetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
