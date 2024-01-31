using Exercie01Contacts.Models;

namespace Exercie01Contacts.Data
{
    public class FakeContactDB
    {
        private List<Contact> _contacts;

        public FakeContactDB()
        {
            _contacts = new List<Contact>()
        {
            new Contact(1, "Jean Bon", "jeanbon@email.fr"),
            new Contact(2, "Bernard Lermitte", "bernardlermitte@email.fr"),
            new Contact(3, "Lara Clette", "laraclette@email.fr" )
        };
        }

        public List<Contact> GetAll() { return _contacts; }

        public Contact? GetById(int id) { return _contacts.FirstOrDefault(model => model.Id == id); }

        public bool Add(Contact contact){ _contacts.Add(contact); return true; }

        public bool Edit(Contact contact) { throw new NotImplementedException(); }

        public bool Remove(Contact contact) { _contacts.Remove(contact); return true; }
    }
}