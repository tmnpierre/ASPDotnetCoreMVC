using Microsoft.AspNetCore.Mvc;

namespace Exercie01Contacts.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
