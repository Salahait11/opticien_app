csharp
using Opticien_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Opticien_APP.Controllers
{
    public class LignOpVenteController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();

        // GET: LignOpVente
        public ActionResult Index(string searchString)
        {
            var lignOpVentes = db.LignOpVentes.Include(l => l.OperationVente).Include(l => l.VERRES).AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                lignOpVentes = lignOpVentes.Where(l => l.Reference.Contains(searchString));
            }
            

            return View(lignOpVentes.ToList());
        }

        // GET: LignOpVente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignOpVente lignOpVente = db.LignOpVentes.Find(id);
            if (lignOpVente == null)
            {
                return HttpNotFound();
            }
            return View(lignOpVente);
        }

        // GET: LignOpVente/Create
        public ActionResult Create() 
        {
            ViewBag.OperationVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp"); 
            ViewBag.VERRESID = new SelectList(db.VERRES, "ID", "TypeDeVerre"); 
            return View(); 
        }

        // POST: LignOpVente/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Reference,Quantité,Remise,PU,OperationVenteID,VERRESID")] LignOpVente lignOpVente)
        {
            if (ModelState.IsValid)
            {
                db.LignOpVentes.Add(lignOpVente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OperationVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp", lignOpVente.OperationVenteID);
            ViewBag.VERRESID = new SelectList(db.VERRES, "ID", "TypeDeVerre", lignOpVente.VERRESID);
            return View(lignOpVente);
        }

        // GET: LignOpVente/Edit/5
        public ActionResult Edit(int? id) 
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignOpVente lignOpVente = db.LignOpVentes.Find(id); 
            if (lignOpVente == null) 
            {
                return HttpNotFound();
            }

            ViewBag.OperationVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp", lignOpVente.OperationVenteID);
            ViewBag.VERRESID = new SelectList(db.VERRES, "ID", "TypeDeVerre", lignOpVente.VERRESID);
            return View(lignOpVente);
        }

        // POST: LignOpVente/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Reference,Quantité,Remise,PU,OperationVenteID,VERRESID")] LignOpVente lignOpVente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lignOpVente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewBag.OperationVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp", lignOpVente.OperationVenteID);
            ViewBag.VERRESID = new SelectList(db.VERRES, "ID", "TypeDeVerre", lignOpVente.VERRESID);
            return View(lignOpVente);
        }

        // GET: LignOpVente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) 
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LignOpVente lignOpVente = db.LignOpVentes.Find(id);
            if (lignOpVente == null)
            {
                return HttpNotFound();
            }
            return View(lignOpVente);
        }

        // POST: LignOpVente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LignOpVente lignOpVente = db.LignOpVentes.Find(id);
            db.LignOpVentes.Remove(lignOpVente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}