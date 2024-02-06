using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Display(Name = "Nom de la catégorie")]
        [Required(ErrorMessage = "Le nom de la catégorie est requis.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom de la catégorie doit être compris entre 3 et 50 caractères.")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public Categorie() { Products = new HashSet<Product>(); }
    }
}