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
    public class VerresController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();

        // GET: Verres
        public ActionResult Index(string searchString)
        {
            var verres = from v in db.Verres
                         select v;
            if (!string.IsNullOrEmpty(searchString))
            {
                verres = verres.Where(v => v.TypeDeVerre.Contains(searchString));
            }

            return View(verres.ToList());
        }

       
        }

        // GET: Verres/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Verres/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TypeDeVerre")] Verres verres)
        {
            if (!ModelState.IsValid)
            {
                 return View(verres);
             }
                db.Verres.Add(verres);
                db.SaveChanges();
                return RedirectToAction("Index");
            

            
        }

        // GET: Verres/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verres verres = db.Verres.Find(id);
            if (verres == null)
            {
                return HttpNotFound();
            }
            return View(verres);
        }

        // POST: Verres/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TypeDeVerre")] Verres verres)
        {
           if (!ModelState.IsValid)
           {
               return View(verres);
           }
           db.Entry(verres).State = EntityState.Modified;
           db.SaveChanges();
           return RedirectToAction("Index");
           
           
        }

         // GET: Verres/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verres verres = db.Verres.Find(id);
            if (verres == null)
            {
                return HttpNotFound();
            }
            return View(verres);
        }
        // GET: Verres/Delete/5
        public ActionResult Delete(int? id)
        {
          if (id == null)
          {
              return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
          }
          Verres verres = db.Verres.Find(id);
          if (verres == null) {
                return HttpNotFound();
            }
            return View(verres);
        }

        // POST: Verres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verres verres = db.Verres.Find(id);
            db.Verres.Remove(verres);
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