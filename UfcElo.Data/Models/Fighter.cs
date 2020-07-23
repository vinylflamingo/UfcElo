using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UfcElo.Data.Models;

namespace UfcElo.Data.Models
{
    public class Fighter
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string Nickname { get; set; }
        [Required]
        public string Hometown { get; set; }
        [Required]
        public int Wins { get; set; }
        [Required]
        public int Losses { get; set; }
        [Required]
        public int Draws { get; set; }
        public int EloRating { get; set; } = 1500;
        public bool IsMale { get; set; } = true;


    }
}