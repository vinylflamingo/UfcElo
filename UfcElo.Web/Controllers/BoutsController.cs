using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.EnterpriseServices;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using UfcElo.Data.Models;
using UfcElo.Data.Services;
using UfcElo.Web.Models;

namespace UfcElo.Web.Controllers
{
    public class BoutsController : Controller
    {
        public  IBoutData boutData;
        public  IFighterData fighterData;
        public  IEloService eloService;
        public BoutsController(IFighterData fighterData, IBoutData boutData, IEloService eloService)
        {
            this.boutData = boutData;
            this.fighterData = fighterData;
            this.eloService = eloService;
        }

        // GET: Bouts
        public ActionResult Index()
        {
            Array fighters = fighterData.GetAll().Reverse().ToArray();
            ViewBag.Fighters = fighters;
            IEnumerable<Bout> model = boutData.GetAll();
            return View(model);
        }


            // GET: Bouts/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Fighters = fighterData.GetAll().ToArray();
            Bout model = boutData.GetBout(id);
            return View(model);
        }

        // GET: Bouts/Create
        public ActionResult Create()
        {
            ViewBag.Fighters = fighterData.GetAll().ToArray().Reverse();
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
            ViewBag.Fighters = fighterData.GetAll().ToArray();
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
            var model = boutData.GetBout(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Bouts/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection formCollection)
        {
            try
            {
                boutData.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //GET: Bouts/FinalizeBout/id
        public ActionResult FinalizeBout(int id)
        {
            
            var model = boutData.GetBout(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.RedFighter = fighterData.GetFighter(model.RedFighterId);
            ViewBag.BlueFighter = fighterData.GetFighter(model.BlueFighterId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FinalizeBout(Bout bout, FormCollection formCollection)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    boutData.Update(bout);
                    bool result = eloService.CalculateNewElo(bout.BoutId);
                    if (result)
                    {
                        return RedirectToAction("Details", new { id = bout.BoutId });
                    }
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create"); 
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return HttpNotFound();
            }

        }

    }
}                                                                                                                            
