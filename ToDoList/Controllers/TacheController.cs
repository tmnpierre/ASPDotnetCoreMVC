using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using ToDoList.Repositories;

namespace ToDoList.Controllers
{
    public class TacheController : Controller
    {
        private readonly ITacheRepository _repository;
        private Random _random = new Random();

        public TacheController(ITacheRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var tache = _repository.GetAll();
            return View(tache);
        }

        public IActionResult Details(int id)
        {
            var tache = _repository.GetById(id);
            if (tache == null)
            {
                return NotFound();
            }

            return View(tache);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Tache newTache)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(newTache);
                return RedirectToAction(nameof(Index));
            }

            return View(newTache);
        }

        [HttpPost]
        public IActionResult AddRandom()
        {
            Tache randomTache = new Tache(
                name: GenerateRandomName(),
                description: GenerateRandomDescription()
                );

            _repository.Add(randomTache);

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        private string GenerateRandomName()
        {
            return RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5, 15);
        }

        [NonAction]
        private string GenerateRandomDescription()
        {
            return RandomString("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 15, 30);
        }

        [NonAction]
        public static string RandomString(string chars, int minLength, int maxLength)
        {
            Random random = new Random();
            int length = random.Next(minLength, maxLength + 1);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IActionResult Remove(int id)
        {
            var result = _repository.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var tache = _repository.GetById(id);
            if (tache == null)
            {
                return NotFound();
            }

            return View(tache);
        }

        [HttpPost]
        public IActionResult Edit(int id, Tache tache)
        {
            if (id != tache.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var success = _repository.Update(tache);
                if (success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", "Une erreur c'est produite");
                }
            }
            return View(tache);
        }
    }
}