using Exercice02Marmosets.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice02Marmosets.Data
{
    public class MarmosetDBContext : DbContext
    {
        public DbSet<Marmoset>? Marmosets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=(localdb)\\MSSQLLocalDB; Database=exerciceMarmosetsDB;");
        }
    }
}
