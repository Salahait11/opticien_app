csharp
--- a/Opticien_APP/Controllers/OperationVenteController.cs
+++ b/Opticien_APP/Controllers/OperationVenteController.cs

using Opticien_APP.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Opticien_APP.Controllers
{
    public class OperationVenteController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();

        // GET: OperationVente
        public ActionResult Index(string searchString)
        {
            var operationVentes = db.OperationVentes.Include(o => o.Client).Include(o => o.Ordonnance).AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                DateTime date;
                if (DateTime.TryParse(searchString, out date))
                {
                    operationVentes = operationVentes.Where(o => o.DateDeVente == date);
                }
                else
                {
                    operationVentes = operationVentes.Where(o => o.NumeroOp.Contains(searchString));
                }
            }

            return View(operationVentes.ToList());
        }

        // GET: OperationVente/Details/5
        public ActionResult Details(int id)
        {
            OperationVente operationVente = db.OperationVentes.Find(id);
            if (operationVente == null)
            {
                return HttpNotFound();
            }
            return View(operationVente);
        }

        // GET: OperationVente/Create
        public ActionResult Create()
        {
            ViewBag.clientID = new SelectList(db.Clients, "ID", "Nom");
            ViewBag.OrdID = new SelectList(db.Ordonnances, "ID", "ID");
            return View();
        }

        // POST: OperationVente/Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NumeroOp,DateDeVente,Montant,clientID,OrdID")] OperationVente operationVente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.clientID = new SelectList(db.Clients, "ID", "Nom", operationVente.clientID);
                ViewBag.OrdID = new SelectList(db.Ordonnances, "ID", "ID", operationVente.OrdID);
                return View(operationVente);
            }
            
                db.OperationVentes.Add(operationVente);
                db.SaveChanges();
                return RedirectToAction("Index");
           
        }

        // GET: OperationVente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OperationVente operationVente = db.OperationVentes.Find(id);
            if (operationVente == null)
            {
                return HttpNotFound();
            }
            ViewBag.clientID = new SelectList(db.Clients, "ID", "Nom", operationVente.clientID);
            ViewBag.OrdID = new SelectList(db.Ordonnances, "ID", "ID", operationVente.OrdID);
            return View(operationVente);
        }

        // POST: OperationVente/Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NumeroOp,DateDeVente,Montant,clientID,OrdID")] OperationVente operationVente)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.clientID = new SelectList(db.Clients, "ID", "Nom", operationVente.clientID);
                ViewBag.OrdID = new SelectList(db.Ordonnances, "ID", "ID", operationVente.OrdID);
                return View(operationVente);
            }
            
                db.Entry(operationVente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
        }

        // GET: OperationVente/Delete/5
        public ActionResult Delete(int id)
        {
            OperationVente operationVente = db.OperationVentes.Find(id);
            if (operationVente == null)
            {
                return HttpNotFound();
            }
            return View(operationVente);
        }

        // POST: OperationVente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OperationVente operationVente = db.OperationVentes.Find(id);
            db.OperationVentes.Remove(operationVente);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) { db.Dispose(); }
            base.Dispose(disposing);
        }
    }
}
