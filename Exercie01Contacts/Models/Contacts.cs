namespace Exercie01Contacts.Models
{
    public class Contacts
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Contacts(int id, string name, string email)
        {
            ID = id;
            Name = name;
            Email = email;
        }
    }
}