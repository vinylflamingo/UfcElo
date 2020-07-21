using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcElo.Data.Models;

namespace UfcElo.Data.Services
{
    public class UfcEloDbContext : DbContext
    {
        public DbSet<Fighter> Fighters { get; set; }
        public DbSet<Bout> Bouts { get; set; }

    }
}
