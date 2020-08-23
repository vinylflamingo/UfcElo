using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UfcElo.Data.Models;

namespace UfcElo.Web.Models
{
    public class AllBoutsViewModel
    {
        public IEnumerable<Fighter> fighters { get; set; }
        public IEnumerable<Bout> bouts { get; set; }
    }
}