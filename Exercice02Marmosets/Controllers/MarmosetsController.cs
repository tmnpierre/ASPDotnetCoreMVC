using Exercice02Marmosets.Models;
using Microsoft.AspNetCore.Mvc;
using Exercice02Marmosets.Data;

namespace Exercice02Marmosets.Controllers
{
    public class MarmosetsController : Controller
    {
        private FakeMarmosetDB _fakeMarmosetDB;
        private Random _random = new Random();

        public MarmosetsController(FakeMarmosetDB fakeMarmosetDB)
        {
            _fakeMarmosetDB = fakeMarmosetDB;
        }

        public IActionResult Index()
        {
            var marmoset = _fakeMarmosetDB.GetAll();
            return View(marmoset);
        }

        public IActionResult Details(int id)
        {
            var marmoset = _fakeMarmosetDB.GetById(id);
            if (marmoset == null)
            {
                return NotFound();
            }

            return View(marmoset);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Marmoset newMarmoset)
        {
            if (ModelState.IsValid)
            {
                newMarmoset.Name = GenerateRandomName();
                newMarmoset.Description = GenerateRandomDescription();
                newMarmoset.Age = _random.Next(1, 12);

                _fakeMarmosetDB.Add(newMarmoset);
                return RedirectToAction(nameof(Index));
            }

            return View(newMarmoset);
        }

        private string GenerateRandomName()
        {
            return "NomAléatoire";
        }

        private string GenerateRandomDescription()
        {
            return "DescriptionAléatoire";
        }
    }
}
