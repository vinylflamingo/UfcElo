using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UfcElo.Data.Models;

namespace UfcElo.Web.Models
{
    public class Fighter
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Nickname { get; set; }
        public string Hometown { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Draws { get; set; }
        public int EloRating { get; set; }
        public bool IsMale { get; set; } = true;
        public WeightClass weightClass { get; set; }


    }
}