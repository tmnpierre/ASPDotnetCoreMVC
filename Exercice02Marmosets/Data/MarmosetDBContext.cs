using Exercice02Marmosets.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice02Marmosets.Data
{
    public class MarmosetDBContext : DbContext
    {
        public DbSet<Marmoset>? Marmosets { get; set; }


        public MarmosetDBContext(DbContextOptions<MarmosetDBContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var marmoset = new List<Marmoset>();
            {
                new Marmoset("Jean Bon", "Tache brune sur la tête", 2);
                new Marmoset("Bernard Lermitte", "Aime les crêpes", 10);
                new Marmoset("Lara Clette", "Aime jouer au ballon", 6);
            }

            modelBuilder.Entity<Marmoset>().HasData(marmoset);
        }
    }
}