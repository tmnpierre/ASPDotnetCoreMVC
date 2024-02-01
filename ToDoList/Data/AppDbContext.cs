using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Tache> ? Taches { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var taches = new List<Tache>();
            {
                new Tache("Ménage", "Netoyer le haut");
                new Tache("Course", "Acheter des pâtes et des lardons");
                new Tache("Cuisine", "Faire des Carbonara");
            }

            modelBuilder.Entity<Tache>().HasData(taches);
        }
    }
}
