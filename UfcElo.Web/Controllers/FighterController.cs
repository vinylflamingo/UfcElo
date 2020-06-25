using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UfcElo.Data.Services;

namespace UfcElo.Web.Controllers
{
    public class FighterController : Controller
    {
        IBoutData boutData;
        IFighterData fighterData;
        public FighterController()
        {
            boutData = new InMemoryBoutData();
            fighterData = new InMemoryFighterData();
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
            return View();
        }

        // GET: Fighter/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Fighter/Create
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

        // GET: Fighter/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Fighter/Edit/5
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

        // GET: Fighter/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Fighter/Delete/5
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
