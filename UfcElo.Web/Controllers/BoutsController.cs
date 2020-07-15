using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UfcElo.Data.Services;
using UfcElo.Web.Models;

namespace UfcElo.Web.Controllers
{
    public class BoutsController : Controller
    {
        IBoutData boutData;
        IFighterData fighterData;
        public BoutsController()
        {
            boutData = new InMemoryBoutData();
            fighterData = new InMemoryFighterData();
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
            ViewBag.Bout = boutData.GetBout(id);
            return View();
        }

        // GET: Bouts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bouts/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bouts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bouts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
