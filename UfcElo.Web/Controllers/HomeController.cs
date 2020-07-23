using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UfcElo.Data.Services;

namespace UfcElo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFighterData fighterData;
        private readonly IBoutData boutData;
        public HomeController(IFighterData fighterData, IBoutData boutData)
        {
            this.boutData = boutData;
            this.fighterData = fighterData;
        }
        public ActionResult Index()
        {

            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}