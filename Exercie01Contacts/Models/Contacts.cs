namespace Exercie01Contacts.Models
{
    public class Contacts
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Contacts(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}