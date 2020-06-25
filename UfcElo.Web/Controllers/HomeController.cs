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
        IBoutData boutData;
        IFighterData fighterData;
        public HomeController()
        {
            boutData = new InMemoryBoutData();
            fighterData = new InMemoryFighterData();
        }
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult Bouts()
        {
            ViewBag.Fighters = fighterData.GetAll();
            ViewBag.Bouts = boutData.GetAll();

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