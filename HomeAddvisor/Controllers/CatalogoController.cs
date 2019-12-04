using HomeAddvisor.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAddvisor.Controllers
{
    public class CatalogoController : Controller
    {
        private HOMEADDVISOR_DBEntities db = new HOMEADDVISOR_DBEntities();
        // GET: Catalogo
        public ActionResult Index()
        {
            List<Profesional> profesionals = db.Profesional.ToList();
            return View(profesionals);
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