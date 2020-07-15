using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UfcElo.Data.Services;
using UfcElo.Data.Models;

namespace UfcElo.Web.Api
{
    public class FighterController : ApiController
    {
        private readonly IFighterData db;

        public FighterController(IFighterData db)
        {
            this.db = db;
        }
        public IEnumerable<Fighter> Get()
        {
            var model = db.GetAll();
            return model;
        }

    }
}
