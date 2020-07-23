using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using UfcElo.Data.Models;

namespace UfcElo.Data.Models
{
    public class Bout
    {
        [Key]
        public int BoutId { get; set; }
        [Required]
        public int RedFighterId { get; set; }
        [Required]
        public int BlueFighterId { get; set; }
        public DateTime? BoutDate { get; set; } = null;
        public string BoutLocation { get; set; }
        public int WinnerId { get; set; }
        public bool IsTitleBout { get; set; }
        public WeightClass WeightClass { get; set; }
        public bool isBoutComplete { get; set; } = false; 

    }
}