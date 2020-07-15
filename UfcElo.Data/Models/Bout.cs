using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UfcElo.Data.Models;

namespace UfcElo.Data.Models
{
    public class Bout
    {
        public int BoutId { get; set; }
        public int RedFighterId { get; set; }
        public int BlueFighterId { get; set; }
        public DateTime BoutDate { get; set; }
        public string BoutLocation { get; set; }
        public int WinnerId { get; set; }
        public bool IsTitleBout { get; set; }
        public WeightClass WeightClass { get; set; }

    }
}