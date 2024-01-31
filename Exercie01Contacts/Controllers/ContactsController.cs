using Exercie01Contacts.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exercie01Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private static List<Contact> contacts = new List<Contact>()
        {
            new Contact(1, "Jean Bon", "jeanbon@email.fr"),
            new Contact(2, "Bernard Lermitte", "bernardlermitte@email.fr")
        };

        public IActionResult Index()
        {
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            return View(contact);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Contact newContact)
        {
            if (ModelState.IsValid)
            {
                newContact.Id = contacts.Any() ? contacts.Max(c => c.Id) + 1 : 1;
                contacts.Add(newContact);
                return RedirectToAction(nameof(Index));
            }

            return View(newContact);
        }
    }
}
