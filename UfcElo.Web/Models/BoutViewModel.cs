using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UfcElo.Data.Models;

namespace UfcElo.Web.Models
{
    public class BoutViewModel
    {
        public IEnumerable<Fighter> fighters { get; set; }
        public Bout bout { get; set; }
    }
}