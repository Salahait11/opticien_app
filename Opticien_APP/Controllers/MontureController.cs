csharp
using Opticien_APP.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Opticien_APP.Controllers
{
    public class MontureController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();

        // GET: Monture
        public ActionResult Index(string searchString)
        {
            var montures = from m in db.Montures
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                montures = montures.Where(s => s.marque.Contains(searchString) || s.couleur.Contains(searchString));
            }
            return View(montures.ToList());
        }
        // GET: Monture/Create
        public ActionResult Create()
        {
            ViewBag.LignOpVente = new SelectList(db.LignOpVentes, "ID", "Reference");
            return View();
        }

        // POST: Monture/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,marque,couleur,taille,Prix,LignOpVente")] Monture monture)//ajout
        {
            if (!ModelState.IsValid)
            {
                ViewBag.LignOpVente = new SelectList(db.LignOpVentes, "ID", "Reference");
                return View(monture);
            }
            db.Montures.Add(monture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Monture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monture monture = db.Montures.Find(id);
            if (monture == null)
            {
                return HttpNotFound();
            }
            ViewBag.LignOpVente = new SelectList(db.LignOpVentes, "ID", "Reference");
            return View(monture);
        }

        // POST: Monture/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,marque,couleur,taille,Prix,LignOpVente")] Monture monture)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.LignOpVente = new SelectList(db.LignOpVentes, "ID", "Reference");
                return View(monture);
            }
            db.Entry(monture).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Monture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monture monture = db.Montures.Find(id);
            if (monture == null)
            {
                return HttpNotFound();
            }
            return View(monture);
        }

        // POST: Monture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Monture monture = db.Montures.Find(id);
            db.Montures.Remove(monture);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET: Monture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Monture monture = db.Montures.Find(id);
            if (monture == null)
            {
                return HttpNotFound();
            }
            return View(monture);