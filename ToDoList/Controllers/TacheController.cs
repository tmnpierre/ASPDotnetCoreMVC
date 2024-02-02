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

        public IActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new Tache());
            else
            {
                var tache = _repository.GetById(id);
                if (tache == null)
                {
                    return NotFound();
                }
                return View(tache);
            }
        }

        [HttpPost]
        public IActionResult AddOrEdit(int id, Tache tache)
        {
            if (ModelState.IsValid)
            {
                if (id == 0)
                {
                    _repository.Add(tache);
                }
                else 
                {
                    var success = _repository.Update(tache);
                    if (!success)
                    {
                        ModelState.AddModelError("", "Une erreur s'est produite lors de la mise à jour.");
                        return View(tache);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tache);
        }

        public IActionResult AddRandom()
        {
            Tache randomTache = new Tache
            {
                Name = GenerateRandomName(),
                Description = GenerateRandomDescription()
            };

            _repository.Add(randomTache);
            return RedirectToAction(nameof(Index));
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

        private string GenerateRandomName()
        {
            return RandomString("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 5, 15);
        }

        private string GenerateRandomDescription()
        {
            return RandomString("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 15, 30);
        }

        public static string RandomString(string chars, int minLength, int maxLength)
        {
            Random random = new Random();
            int length = random.Next(minLength, maxLength + 1);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
