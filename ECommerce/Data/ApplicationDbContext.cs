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
        }
    }
}
