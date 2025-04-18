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
    public class PaiementController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();

        // GET: Paiement
        public ActionResult Index(string searchString)
        {
            var paiements = from p in db.Paiements
                           select p;

            if (!string.IsNullOrEmpty(searchString))
            {
                paiements = paiements.Where(p => p.ModeDePaiement.Contains(searchString));
            }

            return View(paiements.ToList());
        }

        // GET: Paiement/Details/5
        public ActionResult Details(int? id)
        {
             if (id == null) {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Paiement paiement = db.Paiements.Find(id);
             if (paiement == null) {
                 return HttpNotFound();
             }
             return View(paiement);
        }


       

        // GET: Paiement/Create
        public ActionResult Create()
        {
            ViewBag.OpVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp");  // Populate dropdown
            return View();
        }

        // POST: Paiement/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ModeDePaiement,Avance,OpVenteID")] Paiement paiement)
        {
             if (ModelState.IsValid) {
                 try {
                        db.Paiements.Add(paiement);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                 }catch(Exception ex) {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                 }
                
            }
            // If ModelState is not valid, or an exception occurred, repopulate the ViewBag and return the view.
             ViewBag.OpVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp", paiement.OpVenteID);

            return View(paiement);
        }

        // GET: Paiement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paiement paiement = db.Paiements.Find(id);
            if (paiement == null)
            {
                return HttpNotFound();
            }
             ViewBag.OpVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp", paiement.OpVenteID);
            return View(paiement);
        }
         
        // POST: Paiement/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ModeDePaiement,Avance,OpVenteID")] Paiement paiement) {

             if (ModelState.IsValid) {
                try {
                       db.Entry(paiement).State = EntityState.Modified;
                       db.SaveChanges();
                       return RedirectToAction("Index");
                 }catch (Exception ex) {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
             }
             // If ModelState is not valid or exception occurred, repopulate the ViewBag
            ViewBag.OpVenteID = new SelectList(db.OperationVentes, "ID", "NumeroOp", paiement.OpVenteID);
            return View(paiement);
        }
            
        


        // GET: Paiement/Delete/5
        public ActionResult Delete(int? id)
        {
             if (id == null) {
                 return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
             }
             Paiement paiement = db.Paiements.Find(id);
             if (paiement == null) {
                 return HttpNotFound();
             }
             return View(paiement);
        }

        // POST: Paiement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {  Paiement paiement = db.Paiements.Find(id);
            db.Paiements.Remove(paiement);
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