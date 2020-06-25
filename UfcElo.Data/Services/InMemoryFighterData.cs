using System;
using System.Collections.Generic;
using System.Linq;
using UfcElo.Web.Models;

namespace UfcElo.Data.Services
{
    public class InMemoryFighterData : IFighterData
    {
        public List<Fighter> fighters;
        public InMemoryFighterData()
        {
            fighters = new List<Fighter>()
            {
                new Fighter { Id = 1, FirstName = "Daniel", LastName = "Cormier", Hometown = "Los Angeles", Nickname = "DC",
                    Wins = 26, Losses = 2, Draws = 2, IsMale = true, EloRating = 1865 },

                new Fighter { Id = 2, FirstName = "Khabib", LastName = "Nurmagomedov", Hometown = "Dagestan", Nickname = "The Eagle",
                    Wins = 29, Losses = 0, Draws = 0, IsMale = true, EloRating = 2460 },

                new Fighter { Id = 3, FirstName = "Jon", LastName = "Jones", Hometown = "Arizona", Nickname = "Bones",
                    Wins = 17, Losses = 1, Draws = 2, IsMale = true, EloRating = 2500 },

                new Fighter { Id = 4, FirstName = "Amanda", LastName = "Nunes", Hometown = "Los Angeles", Nickname = "DC",
                    Wins = 14, Losses = 1, Draws = 0, IsMale = false, EloRating = 2200 },

                new Fighter { Id = 5, FirstName = "Conor", LastName = "McGregor", Hometown = "Dublin", Nickname = "The Notorious",
                    Wins = 14, Losses = 4, Draws = 0, IsMale = true, EloRating = 1600 },

                new Fighter { Id = 6, FirstName = "CM", LastName = "Punk", Hometown = "WWE", Nickname = "CM Punk",
                    Wins = 0, Losses = 2, Draws = 0, IsMale = true, EloRating = 900 }
            };
        }

        public IEnumerable<Fighter> GetAll()
        {
            return fighters.OrderByDescending(fighter => fighter.EloRating); 
        }
    }
}
