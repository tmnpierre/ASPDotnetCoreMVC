using Exercice02Marmosets.Models;
using Microsoft.EntityFrameworkCore;

namespace Exercice02Marmosets.Data
{
    public class MarmosetDBContext : DbContext
    {
        public DbSet<Marmoset>? Marmosets { get; set; }


        public MarmosetDBContext(DbContextOptions<MarmosetDBContext> options) : base(options)
        {
        }
    }
}