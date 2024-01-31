using System.ComponentModel;

namespace Exercice02Marmosets.Models
{
    public class Marmoset
    {
        public int Id { get; set; }

        [DisplayName("Nom")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Age")]
        public int Age { get; set; }

        public Marmoset(int id, string name, string descripton, int age)
        {
            Id = id;
            Name = name;
            Description = descripton;
            Age = age;
        }
    }
}
