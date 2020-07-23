using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcElo.Data.Models;

namespace UfcElo.Data.Services
{
    public class SqlFighterData : IFighterData
    {
        private readonly UfcEloDbContext db;
        public SqlFighterData(UfcEloDbContext db)
        {
            this.db = db;
        }
        public void Add(Fighter fighter)
        {
            db.Fighters.Add(fighter);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var fighter = db.Fighters.Find(id);
            db.Fighters.Remove(fighter);
            db.SaveChanges();
        }

        public IEnumerable<Fighter> GetAll()
        {
            return db.Fighters.OrderByDescending(fighter => fighter.EloRating);
        }

        public Fighter GetFighter(int id)
        {
            return db.Fighters.FirstOrDefault(fighter => fighter.Id == id);
        }

        public void Update(Fighter fighter)
        {
            var entry = db.Entry(fighter);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
