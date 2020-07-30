using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UfcElo.Data.Models;
using UfcElo.Data.Services;

namespace UfcElo.Tests
{
    [TestClass]
    public class EloServiceShould
    {
        public EloServiceShould()
        {
        }


        [TestMethod]
        public void CalculateProbabilityCorrectly()
        {
            var FighterElo = 1200;
            var OpponentElo = 1000;
            var context = new UfcEloDbContext();
            var fighterData = new SqlFighterData(context);
            var boutData = new SqlBoutData(context);
            var eloService = new EloService(context);


            double result = eloService.ProbabilityOfWin(FighterElo, OpponentElo);
            Console.WriteLine("Probability of Win. Should Be 0.76");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Result: " + result);
            Assert.IsTrue(result == 0.76);

            
        }

        [TestMethod]
        public void CalculateNewEloCorrectly()
        {

            //mock fighters 
            (Fighter, Fighter) fighters =
                (
                    new Fighter
                    {
                        FirstName = "Frank",
                        LastName = "Costoya",
                        EloRating = 1000,
                        Hometown = "Miami, FL",
                        Id = 1,
                        IsMale = true,
                        Nickname = "The Tank",
                        Wins = 15,
                        Losses = 2,
                        Draws = 1
                    },
                    new Fighter
                    {
                        FirstName = "Kevin",
                        LastName = "Debs",
                        EloRating = 1000,
                        Hometown = "Miami, FL",
                        Id = 2,
                        IsMale = true,
                        Nickname = "The Rogue",
                        Wins = 15,
                        Losses = 2,
                        Draws = 1
                    }
                );
            //mock bout
            Bout bout = new Bout
            {
                RedFighterId = 1,
                BlueFighterId = 2,
                BoutId = 1,
                BoutDate = new DateTime(2020, 12, 25),
                BoutLocation = "Miami, FL",
                WeightClass = WeightClass.Heavyweight,
                isBoutComplete = false,
                IsTitleBout = false,
                WinnerId = 1
            };

            //access to the needed classes
            var context = new UfcEloDbContext();
            var eloService = new EloService(context);

            var result = eloService.CalculateNewElo(fighters, bout);

            Console.WriteLine("Red Fighter Updated Elo. Should Be 1015");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Result: " + result.RedFighter.EloRating);
            Assert.IsTrue(result.RedFighter.EloRating == 1015);

            Console.WriteLine("Blue Fighter Updated Elo. Should Be 985");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Result: " + result.RedFighter.EloRating);
            Assert.IsTrue(result.BlueFighter.EloRating == 985);


        }
    }
}
