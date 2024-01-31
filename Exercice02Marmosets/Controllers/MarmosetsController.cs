using Exercice02Marmosets.Models;
using Microsoft.AspNetCore.Mvc;
using Exercice02Marmosets.Data;

namespace Exercice02Marmosets.Controllers
{
    public class MarmosetsController : Controller
    {
        private FakeMarmosetDB _fakeMarmosetDB;

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
                _fakeMarmosetDB.Add(newMarmoset);
                return RedirectToAction(nameof(Index));
            }

            return View(newMarmoset);
        }
    }
}
