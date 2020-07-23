using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcElo.Data.Models;

namespace UfcElo.Data.Services
{
    public class EloService : IEloService
    {
        private UfcEloDbContext db;
        private int k;

        public EloService(UfcEloDbContext db)
        {
            // k = maximum amount of points a fighter can gain or lose from a bout. 
            k = 30;
            this.db = db;
        }

        public double ProbabilityOfWin(double FighterElo, double FighterOpponentElo)
        {
            return Math.Round(1.0 * 1.0 / (1 + 1.0 * (double)
                   (Math.Pow(10, 1.0 * (FighterOpponentElo - FighterElo) / 400))), 2);
        }

        public bool CalculateNewElo(int BoutId)
        {
            //pull the required objects to make comparisons 
            Bout bout = db.Bouts.FirstOrDefault(b => b.BoutId == BoutId);

            Fighter RedFighter = db.Fighters.FirstOrDefault(f => f.Id == bout.RedFighterId);
            Fighter BlueFighter = db.Fighters.FirstOrDefault(f => f.Id == bout.BlueFighterId);
            Debug.WriteLine(RedFighter.FirstName);

            //find the probability of win.
            double ProbabilityRedWin = ProbabilityOfWin(RedFighter.EloRating, BlueFighter.EloRating);
            double ProbabilityBlueWin = ProbabilityOfWin(RedFighter.EloRating, BlueFighter.EloRating);

            if (bout.WinnerId == RedFighter.Id)
            {
                RedFighter.EloRating = RedFighter.EloRating + (int)(k * (1 - ProbabilityRedWin));
                BlueFighter.EloRating = BlueFighter.EloRating + (int)(k * (0 - ProbabilityBlueWin));
            }
            else if (bout.WinnerId == BlueFighter.Id)
            {
                RedFighter.EloRating = RedFighter.EloRating + (int)(k * (0 - ProbabilityRedWin));
                BlueFighter.EloRating = BlueFighter.EloRating + (int)(k * (1 - ProbabilityBlueWin));
            }
            else
            {     
                return false;
            }
            try
            {

                Debug.WriteLine("RedFighter Elo : " + RedFighter.EloRating);
                var RFentry = db.Entry(RedFighter);
                RFentry.State = EntityState.Modified;
                db.SaveChanges();

                Debug.WriteLine("RedFighter Elo : " + RedFighter.EloRating);
                var BFentry = db.Entry(RedFighter);
                BFentry.State = EntityState.Modified;
                db.SaveChanges();


            }
            catch
            {
                return false;
            }
            return true;

        }

    }
}
