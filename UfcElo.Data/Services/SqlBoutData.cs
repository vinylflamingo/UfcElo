using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcElo.Data.Models;

namespace UfcElo.Data.Services
{
    public class SqlBoutData : IBoutData
    {
        private readonly UfcEloDbContext db;

        public SqlBoutData(UfcEloDbContext db)
        {
            this.db = db;
        }
        public void Add(Bout bout)
        {
            db.Bouts.Add(bout);
            db.SaveChanges();
        }

        public IEnumerable<Bout> GetAll()
        {
            return db.Bouts.OrderByDescending(bout => bout.BoutDate);
        }

        public Bout GetBout(int id)
        {
            return db.Bouts.FirstOrDefault(bout => bout.BoutId == id);
        }

        public void Update(Bout bout)
        {
            var entry = db.Entry(bout);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
