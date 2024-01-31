using Exercice02Marmosets.Models;

namespace Exercice02Marmosets.Data
{
    public class FakeMarmosetDB
    {
        private List<Marmoset> _marmoset;
        private int _lastId = 0;

        public FakeMarmosetDB()
        {
            _marmoset = new List<Marmoset>()
        {
            new Marmoset(++_lastId, "Jean Bon", "Tache brune sur la tête", 2),
            new Marmoset(++_lastId, "Bernard Lermitte", "Aime les crêpe", 10),
            new Marmoset(++_lastId, "Lara Clette", "Aime jouer au ballon", 6)
        };
        }

        public List<Marmoset> GetAll() { return _marmoset; }

        public Marmoset? GetById(int id) { return _marmoset.FirstOrDefault(model => model.Id == id); }

        public bool Add(Marmoset contact) { contact.Id = ++_lastId; _marmoset.Add(contact); return true; }

        public bool Edit(Marmoset marmoset)
        {
            var marmosetFromDB = GetById(marmoset.Id);
            if (marmosetFromDB == null) return false;
            marmosetFromDB.Name = marmoset.Name;
            marmosetFromDB.Description = marmoset.Description;
            marmosetFromDB.Age = marmoset.Age;
            return true;
        }

        public bool Remove(int id)
        {
            var marmoset = GetById(id);
            if (marmoset == null)
            {
                return false;
            }
            _marmoset.Remove(marmoset);
            return true;
        }
    }
}
