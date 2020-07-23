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
    }
}
