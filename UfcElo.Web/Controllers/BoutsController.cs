using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UfcElo.Data.Models;
using UfcElo.Data.Services;
using UfcElo.Web.Models;

namespace UfcElo.Web.Controllers
{
    public class BoutsController : Controller
    {
        private readonly IBoutData boutData;
        private readonly IFighterData fighterData;
        public BoutsController(IFighterData fighterData, IBoutData boutData)
        {
            this.boutData = boutData;
            this.fighterData = fighterData;
        }

        // GET: Bouts
        public ActionResult Index()
        {
            ViewBag.Fighters = fighterData.GetAll();
            ViewBag.Bouts = boutData.GetAll();

            return View();
        }


            // GET: Bouts/Details/5
        public ActionResult Details(int id)
        {

            var bout = boutData.GetBout(id);
            ViewBag.Bout = bout;
            ViewBag.BlueFighter = fighterData.GetFighter(bout.BlueFighterId);
            ViewBag.RedFighter = fighterData.GetFighter(bout.RedFighterId);
            return View();
        }

        // GET: Bouts/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Bouts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Bout bout)
        {
            try
            {
                // TODO: Add insert logic here
                boutData.Add(bout);
                return RedirectToAction("Details", new { id = bout.BoutId });
            }
            catch
            {
                return View();
            }
        }

        // GET: Bouts/Edit/5
        public ActionResult Edit(int id)
        {
            var model = boutData.GetBout(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Bouts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bout bout)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    boutData.Update(bout);
                    return RedirectToAction("Details", new { id = bout.BoutId });
                }
                return View(bout);
            }
            catch
            {
                return View();
            }
        }

        // GET: Bouts/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bouts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
