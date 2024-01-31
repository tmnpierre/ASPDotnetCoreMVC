using Exercice02Marmosets.Models;
using Exercice02Marmosets.Data;
using Microsoft.AspNetCore.Mvc;

namespace Exercice02Marmosets.Controllers
{
    public class MarmosetsController : Controller
    {
        private readonly MarmosetDBContext _context;
        private Random _random = new Random();

        public MarmosetsController(MarmosetDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var marmosets = _context.Marmosets.ToList();
            return View(marmosets);
        }

        public IActionResult Details(int id)
        {
            var marmoset = _context.Marmosets.FirstOrDefault(m => m.Id == id);
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
                _context.Marmosets.Add(newMarmoset);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(newMarmoset);
        }

        [HttpPost]
        public IActionResult AddRandom()
        {
            int lastId = _context.Marmosets.Any() ? _context.Marmosets.Max(m => m.Id) : 0;

            Marmoset randomMarmoset = new Marmoset(
                name: GenerateRandomName(),
                description: GenerateRandomDescription(),
                age: _random.Next(1, 50)
            );

            _context.Marmosets.Add(randomMarmoset);
            _context.SaveChanges();

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
            var marmoset = _context.Marmosets.FirstOrDefault(m => m.Id == id);
            if (marmoset == null)
            {
                return NotFound();
            }

            _context.Marmosets.Remove(marmoset);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
