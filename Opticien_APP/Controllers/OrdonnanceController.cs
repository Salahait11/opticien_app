csharp
using Opticien_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace Opticien_APP.Controllers
{
    public class OrdonnanceController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();

        // GET: Ordonnance
        public ActionResult Index(string searchString)
        {
            var ordonnances = db.Ordonnances.Include(o => o.Medecin).AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                DateTime date;
                if(DateTime.TryParse(searchString, out date)) ordonnances = ordonnances.Where(o => o.DateDePrescription == date);
            }
            return View(ordonnances.ToList());
        }

        // GET: Ordonnance/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            if (ordonnance == null) { return HttpNotFound(); }

            return View(ordonnance);
          
        }

        // GET: Ordonnance/Create
        public ActionResult Create()
        {
            ViewBag.medecinID = new SelectList(db.Medecins, "ID", "nom");
            return View();
        }

        // POST: Ordonnance/Create        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateDePrescription,OD_VL_SPH,OD_VL_CYL,OD_VL_AXE,OD_VL_ADD,OD_VL_EP,OD_VL_H,OD_VL_DAIM,OG_VL_SPH,OG_VL_CYL,OG_VL_AXE,OG_VL_ADD,OG_VL_EP,OG_VL_H,OG_VL_DAIM,OD_VP_SPH,OD_VP_CYL,OD_VP_AXE,OD_VP_ADD,OD_VP_EP,OD_VP_H,OD_VP_DAIM,OG_VP_SPH,OG_VP_CYL,OG_VP_AXE,OG_VP_ADD,OG_VP_EP,OG_VP_H,OG_VP_DAIM,medecinID")] Ordonnance ordonnance)
        {   
              if (!ModelState.IsValid) {
                ViewBag.medecinID = new SelectList(db.Medecins, "ID", "nom", ordonnance.medecinID);
                return View(ordonnance);
              }                
                db.Ordonnances.Add(ordonnance);            
                db.SaveChanges();
                return RedirectToAction("Index");            

        }

        // GET: Ordonnance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            if (ordonnance == null)
            {
                return HttpNotFound();
            }
            ViewBag.medecinID = new SelectList(db.Medecins, "ID", "nom", ordonnance.medecinID);
            return View(ordonnance);
        }

        // POST: Ordonnance/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DateDePrescription,OD_VL_SPH,OD_VL_CYL,OD_VL_AXE,OD_VL_ADD,OD_VL_EP,OD_VL_H,OD_VL_DAIM,OG_VL_SPH,OG_VL_CYL,OG_VL_AXE,OG_VL_ADD,OG_VL_EP,OG_VL_H,OG_VL_DAIM,OD_VP_SPH,OD_VP_CYL,OD_VP_AXE,OD_VP_ADD,OD_VP_EP,OD_VP_H,OD_VP_DAIM,OG_VP_SPH,OG_VP_CYL,OG_VP_AXE,OG_VP_ADD,OG_VP_EP,OG_VP_H,OG_VP_DAIM,medecinID")] Ordonnance ordonnance)        
        {           
              if (!ModelState.IsValid) {
                ViewBag.medecinID = new SelectList(db.Medecins, "ID", "nom", ordonnance.medecinID);
                return View(ordonnance);
              }        
                db.Entry(ordonnance).State = EntityState.Modified;            
                db.SaveChanges();
                return RedirectToAction("Index");           

        }




        // GET: Ordonnance/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            return View(ordonnance);
            
        }

        // POST: Ordonnance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ordonnance ordonnance = db.Ordonnances.Find(id);
            db.Ordonnances.Remove(ordonnance);
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