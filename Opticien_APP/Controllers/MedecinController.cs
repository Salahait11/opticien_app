csharp
using Opticien_APP.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Opticien_APP.Controllers
{
    public class MedecinController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();

        // GET: Medecin
        public ActionResult Index(string searchString)
        {
            var medecins = from m in db.Medecins
                           select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                medecins = medecins.Where(m => m.nom.Contains(searchString) || m.prenom.Contains(searchString));
            }
            return View(medecins.ToList());
        }

        // GET: Medecin/Details/5
        public ActionResult Details(int? id)
        {
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medecin medecin = db.Medecins.Find(id);
            if (medecin == null)
            {
                return HttpNotFound() ;
            }
            return View(medecin);
        }

        // GET: Medecin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medecin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nom,prenom,gsm")] Medecin medecin) 
        
        { if (!ModelState.IsValid)
            {
                return View(medecin);
            }
            if (ModelState.IsValid)
            {
                db.Medecins.Add(medecin);
             db.SaveChanges();
                return RedirectToAction("Index");
               
            }return View(medecin);
        }

        // GET: Medecin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medecin medecin = db.Medecins.Find(id);
            if (medecin == null)
            {
                return HttpNotFound();
            }
            return View(medecin);
        }

        // POST: Medecin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nom,prenom,gsm")] Medecin medecin) 
        { if (!ModelState.IsValid) 
            {
                return View(medecin);
            }
            if (ModelState.IsValid)
            {
                 db.Entry(medecin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
           } return View(medecin);
        }

        // GET: Medecin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medecin medecin = db.Medecins.Find(id);
            if (medecin == null)
            {
                return HttpNotFound();
            }
            return View(medecin);
        }

        // POST: Medecin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medecin medecin = db.Medecins.Find(id);
            db.Medecins.Remove(medecin);
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