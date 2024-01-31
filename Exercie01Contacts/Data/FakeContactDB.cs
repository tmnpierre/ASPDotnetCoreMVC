using Exercie01Contacts.Models;

namespace Exercie01Contacts.Data
{
    public class FakeContactDB
    {
        private List<Contact> _contacts;
        private int _lastId = 0;

        public FakeContactDB()
        {
            _contacts = new List<Contact>()
        {
            new Contact(++_lastId, "Jean Bon", "jeanbon@email.fr"),
            new Contact(++_lastId, "Bernard Lermitte", "bernardlermitte@email.fr"),
            new Contact(++_lastId, "Lara Clette", "laraclette@email.fr" )
        };
        }

        public List<Contact> GetAll() { return _contacts; }

        public Contact? GetById(int id) { return _contacts.FirstOrDefault(model => model.Id == id); }

        public bool Add(Contact contact) { contact.Id = ++_lastId; _contacts.Add(contact); return true; }

        public bool Edit(Contact contact)
        {
            var contactFromDB = GetById(contact.Id);
            if (contactFromDB == null) return false;
            contactFromDB.Name = contact.Name;
            contactFromDB.Email = contact.Email;
            return true;
        }

        public bool Remove(int id)
        {
            var contact = GetById(id);
            if (contact == null)
            {
                return false;
            }
            _contacts.Remove(contact);
            return true;
        }
    }
}