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

        public (Fighter RedFighter, Fighter BlueFighter) FindFighterByBoutId(int BoutId)
        {
            Bout bout = db.Bouts.FirstOrDefault(b => b.BoutId == BoutId);
            Fighter RedFighter = db.Fighters.FirstOrDefault(f => f.Id == bout.RedFighterId);
            Fighter BlueFighter = db.Fighters.FirstOrDefault(f => f.Id == bout.BlueFighterId);
            return (RedFighter, BlueFighter);
        }


        public (Fighter RedFighter, Fighter BlueFighter) CalculateNewElo((Fighter RedFighter, Fighter BlueFighter) fighters, Bout bout)
        {
            //pull the required objects to make comparisons 
            Debug.WriteLine(fighters.RedFighter.FirstName);

            //find the probability of win.
            double ProbabilityRedWin = ProbabilityOfWin(fighters.RedFighter.EloRating, fighters.BlueFighter.EloRating);
            double ProbabilityBlueWin = ProbabilityOfWin(fighters.RedFighter.EloRating, fighters.BlueFighter.EloRating);

            if (bout.WinnerId == fighters.RedFighter.Id)
            {
                fighters.RedFighter.EloRating = fighters.RedFighter.EloRating + (int)(k * (1 - ProbabilityRedWin));
                fighters.BlueFighter.EloRating = fighters.BlueFighter.EloRating + (int)(k * (0 - ProbabilityBlueWin));
            }
            else if (bout.WinnerId == fighters.BlueFighter.Id)
            {
                fighters.RedFighter.EloRating = fighters.RedFighter.EloRating + (int)(k * (0 - ProbabilityRedWin));
                fighters.BlueFighter.EloRating = fighters.BlueFighter.EloRating + (int)(k * (1 - ProbabilityBlueWin));
            }
            else
            {
                Debug.WriteLine("Calculation Failed. Original Elo's Restored");
                return fighters;
            }

            Debug.WriteLine("Calculation Completed. Returning new Elo Scores");
            return fighters;
        }

        public bool UpdateNewElo((Fighter, Fighter) fighters)
        {
            try
            {

                Debug.WriteLine("RedFighter Elo : " + fighters.Item1.EloRating);
                var RFentry = db.Entry(fighters.Item1);
                RFentry.State = EntityState.Modified;
                db.SaveChanges();

                Debug.WriteLine("BlueFighter Elo : " + fighters.Item2.EloRating);
                var BFentry = db.Entry(fighters.Item2);
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
