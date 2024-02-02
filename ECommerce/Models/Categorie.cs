using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        [Display(Name = "Nom de la catégorie")]
        [Required(ErrorMessage = "Le nom de la catégorie est requis.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom de la catégorie doit être compris entre 3 et 50 caractères.")]
        public string? Name { get; set; }

        [Display(Name = "Liste de produits de la catégorie")]
        public List<Product>? Products { get; set; }

        public Categorie(string name, List<Product> products)
        {
            Name = name;
            Products = products;
        }
    }
}
