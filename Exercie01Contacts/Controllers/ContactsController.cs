using Microsoft.AspNetCore.Mvc;

namespace Exercie01Contacts.Controllers
{
    public class ContactsController : Controller
    {
        public string Index()
        {
            return "Je suis la page pour afficher tous les contacts.";
        }

        public string Details(int id)
        {
            return $"Je suis la page pour afficher le contact #{id} en detail ...";
        }

        public string Add()
        {
            return "Je suis la page pour ajouter un contacts.";
        }
    }
}
