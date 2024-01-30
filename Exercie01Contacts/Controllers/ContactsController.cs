using Exercie01Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercie01Contacts.Controllers
{
    public class ContactsController : Controller
    {

        private static List<Contacts> contacts = new List<Contacts>()
        {
            new Contacts(1, "Jean Bon", "jeanbon@email.fr"),
            new Contacts(2, "Bernard Lermitte", "bernardlermitte@email.fr")
        };

        public IActionResult Index()
        {
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var contact = contacts.Find(c => c.Id == id);
            return View(contact);
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}