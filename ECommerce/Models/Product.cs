using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Nom du produit")]
        [Required(ErrorMessage = "Le nom du produit est requis.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Le nom du produit doit être compris entre 3 et 50 caractères.")]
        public string Name { get; set; }

        [Display(Name = "Marque du produit")]
        [Required(ErrorMessage = "La marque du produit est requise.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "La marque du produit doit être comprise entre 3 et 20 caractères.")]
        public string Brand { get; set; }

        [Display(Name = "Description du produit")]
        [Required(ErrorMessage = "La description du produit est requise.")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "La description du produit doit être comprise entre 10 et 100 caractères.")]
        public string Description { get; set; }

        [Display(Name = "Prix du produit")]
        [Required(ErrorMessage = "Le prix du produit est requis.")]
        public decimal Price { get; set; }

        [Display(Name = "Quantité en stock du produit")]
        [Required(ErrorMessage = "La quantité en stock du produit est requise.")]
        public int QuantityInStock { get; set; }

        [Display(Name = "Catégorie du produit")]
        public int CategorieId { get; set; }

        [ForeignKey("CategorieId")]
        public virtual Categorie Categorie { get; set; }

        [Display(Name = "Illustration du produit")]
        public string PicturePath { get; set; }
    }
}