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
            AllBoutsViewModel model = new AllBoutsViewModel
            {
                fighters = fighterData.GetAll(),
                bouts = boutData.GetAll()
            };
            return View(model);
        }


            // GET: Bouts/Details/5
        public ActionResult Details(int id)
        {
            BoutViewModel model = new BoutViewModel
            {
                fighters = fighterData.GetAll(),
                bout = boutData.GetBout(id)
            };
            return View(model);
        }

        [Authorize]
        // GET: Bouts/Create
        public ActionResult Create()
        {
            ViewBag.Fighters = fighterData.GetAll().Reverse().ToList();
            return View();
        }

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
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

        [Authorize]
        //GET: Bouts/FinalizeBout/id
        public ActionResult FinalizeBout(int id)
        {

            ViewBag.Fighters = fighterData.GetAll().ToArray();
            var model = boutData.GetBout(id);
            if (model.isBoutComplete == true)
            {
                return RedirectToAction("Index");
            }
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.RedFighter = fighterData.GetFighter(model.RedFighterId);
            ViewBag.BlueFighter = fighterData.GetFighter(model.BlueFighterId);
            return View(model);
        }

        [Authorize]
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
                    var fighters = eloService.FindFighterByBoutId(bout.BoutId);
                    var newElos = eloService.CalculateNewElo(fighters, bout);
                    bool result = eloService.UpdateNewElo(newElos);
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
