using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Opticien_APP.Models;

namespace Opticien_APP.Controllers
{
    public class HomeController : Controller
    {
        private OpticienDbContext db = new OpticienDbContext();
        public ActionResult Index()
        {
            try
            {
                var ordonnances = db.Ordonnances.Include(o => o.Medecin).Take(3).ToList();
                return View(ordonnances);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Home", "Index"));
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}