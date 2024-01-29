using Exercie01Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Exercie01Contacts.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public string ToutLesContacts()
        {
            return "Je suis la page pour afficher tous les contacts.";
        }

        public string AfficherContact()
        {
            return "Je suis la page pour afficher un contacts.";
        }

        public string AjouterContact()
        {
            return "Je suis la page pour ajouter un contacts.";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
