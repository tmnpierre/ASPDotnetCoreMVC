using Microsoft.AspNetCore.Mvc;

namespace Exercie01Contacts.Controllers
{
    public class ContactsController : Controller
    {
        private int ID { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }

        public ContactsController(int id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            List<ContactsController> contacts = new List<ContactsController>();
            {
                contacts.Add(new ContactsController(ID = 1, Name = "Jean Bon", Email = "jeanbon@emial.fr"));
                contacts.Add(new ContactsController(ID = 2, Name = "Bernard Lermitte", Email = "bernardlermitte@emial.fr"));
            }

            return View();
        }

        public IActionResult Add()
        {
            return View();
        }
    }
}
