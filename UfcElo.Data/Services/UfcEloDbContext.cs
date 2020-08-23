using System.Data.Entity;
using UfcElo.Data.Models;

namespace UfcElo.Data.Services
{
    public class UfcEloDbContext : DbContext
    {
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Bout> Bouts { get; set; }


    }
}
