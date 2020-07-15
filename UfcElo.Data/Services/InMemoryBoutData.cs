﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UfcElo.Data.Models;


namespace UfcElo.Data.Services
{

    //TEMPORARY
    public class InMemoryBoutData :IBoutData
    {        
        List<Bout> bouts;
        public InMemoryBoutData()
        {
            bouts = new List<Bout>()
            {
              new Bout { BoutId = 0, BlueFighterId = 1, RedFighterId = 3, BoutDate = new DateTime(2017, 6, 21),
                  BoutLocation = "Las Vegas", IsTitleBout = true, WeightClass = WeightClass.LightHeavyweight, WinnerId = 1 },
              new Bout { BoutId = 1,BlueFighterId = 2, RedFighterId = 5, BoutDate = new DateTime(2019, 2, 4),
                  BoutLocation = "Dubai", IsTitleBout = true, WeightClass = WeightClass.Lightweight, WinnerId = 2 },
              new Bout { BoutId = 2,BlueFighterId = 6, RedFighterId = 4, BoutDate = new DateTime(2021, 10, 14),
                  BoutLocation = "Wrestlemania", IsTitleBout = false, WeightClass = WeightClass.WFeatherweight, WinnerId = 4 }
            };
        }

        public IEnumerable<Bout> GetAll()
        {
            return bouts.OrderBy(bout => bout.BoutDate);
        }

        public Bout GetBout(int id)
        {
            return bouts.FirstOrDefault(x => x.BoutId == id);
        }
    }
}
