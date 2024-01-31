using Exercie01Contacts.Models;
using Microsoft.AspNetCore.Mvc;
using Exercie01Contacts.Data;

namespace Exercie01Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private FakeContactDB _fakeContactDB;

        // Utilisation de l'injection de dépendance pour FakeContactDB
        public ContactsController(FakeContactDB fakeContactDB)
        {
            _fakeContactDB = fakeContactDB;
        }

        public IActionResult Index()
        {
            var contacts = _fakeContactDB.GetAll();
            return View(contacts);
        }

        public IActionResult Details(int id)
        {
            var contact = _fakeContactDB.GetById(id);
            if (contact == null)
            {
                return NotFound();
            }

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
                _fakeContactDB.Add(newContact);
                return RedirectToAction(nameof(Index));
            }

            return View(newContact);
        }
    }
}
