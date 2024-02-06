using ECommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasKey(p => p.Id);
            modelBuilder.Entity<Categorie>().HasKey(c => c.Id);

            modelBuilder.Entity<Categorie>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Categorie)
                .HasForeignKey(p => p.CategorieId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18, 2)");

            var categories = new[]
            {
                new Categorie { Id = 1, Name = "Électronique" },
                new Categorie { Id = 2, Name = "Livres" }
            };

            var products = new[]
            {
                new Product { Id = 1, Name = "Ordinateur Portable", Brand = "Marque A", Description = "Un ordinateur portable de haute qualité.", Price = 999.99m, QuantityInStock = 10, CategorieId = 1, PicturePath = "chemin/vers/image1.jpg" },
                new Product { Id = 2, Name = "Livre de programmation", Brand = "Marque B", Description = "Apprenez à programmer avec ce livre.", Price = 39.99m, QuantityInStock = 20, CategorieId = 2, PicturePath = "chemin/vers/image2.jpg" }
            };

            modelBuilder.Entity<Categorie>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}