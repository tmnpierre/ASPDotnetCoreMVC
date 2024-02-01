using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class ToDoLists
    {
        public int Id { get; set; }

        [Display(Name = "Titre de la tâche")]
        public string Name { get; set; }

        [Display(Description = "Description de la tâche")]
        public string Description { get; set; }
    }
}
