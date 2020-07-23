using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UfcElo.Data.Models;
using UfcElo.Data.Services;

namespace UfcElo.Web.Controllers
{
    public class FighterController : Controller
    {

        private readonly IFighterData fighterData;
        private readonly IBoutData boutData;

        public FighterController(IFighterData fighterData, IBoutData boutData)
        {
            this.boutData = boutData;
            this.fighterData = fighterData;
            
        }

        // GET: Fighter
        public ActionResult Index()
        {

            var model = fighterData.GetAll();
            return View(model);
        }

        // GET: Fighter/Details/5
        public ActionResult Details(int id)
        {
            var model = fighterData.GetFighter(id);
            if(model == null)
            {
                return View("NotFound");
            }
            return View(model);
        }

        // GET: Fighter/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fighter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Fighter fighter)
        {
            try
            {
                // TODO: Add insert logic here
                fighterData.Add(fighter);
                return RedirectToAction("Details", new { id = fighter.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Fighter/Edit/5
        public ActionResult Edit(int id)
        {
            var model = fighterData.GetFighter(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Fighter/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Fighter fighter)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    fighterData.Update(fighter);
                    return RedirectToAction("Details", new { id = fighter.Id });
                }
                return View(fighter);
            }
            catch
            {
                return View();
            }
        }

        // GET: Fighter/Delete/5
        public ActionResult Delete(int id)
        {
            var model = fighterData.GetFighter(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: Fighter/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection form)
        {
            try
            {
                fighterData.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
