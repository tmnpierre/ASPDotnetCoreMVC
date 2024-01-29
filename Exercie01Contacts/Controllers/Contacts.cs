using Microsoft.AspNetCore.Mvc;

namespace Exercie01Contacts.Controllers
{
    public class Contacts : Controller
    {
        public string Index()
        {
            return "Je suis la page pour afficher tous les contacts.";
        }

        public string Details()
        {
            return "Je suis la page pour afficher un contacts.";
        }

        public string Add()
        {
            return "Je suis la page pour ajouter un contacts.";
        }
    }
}
