using Exercice02Marmosets.Models;
using Microsoft.AspNetCore.Mvc;
using Exercice02Marmosets.Data;
using System;

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
            var marmosets = _fakeMarmosetDB.GetAll();
            return View(marmosets);
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

        [HttpPost]
        public IActionResult AddRandom()
        {
            int lastId = _fakeMarmosetDB.GetAll().Max(m => m.Id);

            Marmoset randomMarmoset = new Marmoset(
                id: lastId + 1,
                name: GenerateRandomName(),
                description: GenerateRandomDescription(),
                age: _random.Next(1, 50)
            );

            _fakeMarmosetDB.Add(randomMarmoset);

            var marmosets = _fakeMarmosetDB.GetAll();
            return View("Index", marmosets);
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

        public IActionResult Remove(int id)
        {
            var marmoset = _fakeMarmosetDB.GetById(id);
            if (marmoset == null)
            {
                return NotFound();
            }

            _fakeMarmosetDB.Remove(marmoset.Id); 
            return RedirectToAction(nameof(Index));
        }
    }
}
