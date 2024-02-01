using Exercice02Marmosets.Models;
using Microsoft.AspNetCore.Mvc;
using Exercice02Marmosets.Repositories;

namespace Exercice02Marmosets.Controllers
{
    public class MarmosetsController : Controller
    {
        private readonly IMarmosetRepository _repository;
        private Random _random = new Random();

        public MarmosetsController(IMarmosetRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var marmosets = _repository.GetAll();
            return View(marmosets);
        }

        public IActionResult Details(int id)
        {
            var marmoset = _repository.GetById(id);
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
                _repository.Add(newMarmoset);
                return RedirectToAction(nameof(Index));
            }

            return View(newMarmoset);
        }

        [HttpPost]
        public IActionResult AddRandom()
        {
            Marmoset randomMarmoset = new Marmoset(
                name: GenerateRandomName(),
                description: GenerateRandomDescription(),
                age: _random.Next(1, 50)
            );

            _repository.Add(randomMarmoset);

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
    }
}
