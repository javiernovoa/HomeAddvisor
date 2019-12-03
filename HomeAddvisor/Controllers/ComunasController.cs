using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HomeAddvisor.DB;

namespace HomeAddvisor.Controllers
{
    public class ComunasController : Controller
    {
        private HOMEADDVISOR_DBEntities db = new HOMEADDVISOR_DBEntities();

        // GET: Comunas
        public ActionResult Index()
        {
            return View(db.Comuna.ToList());
        }

        // GET: Comunas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuna comuna = db.Comuna.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // GET: Comunas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Comunas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Comuna,Nombre_Comuna,CodigoPostal_Comuna,Sector,Gse")] Comuna comuna)
        {
            if (ModelState.IsValid)
            {
                db.Comuna.Add(comuna);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(comuna);
        }

        // GET: Comunas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuna comuna = db.Comuna.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // POST: Comunas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Comuna,Nombre_Comuna,CodigoPostal_Comuna,Sector,Gse")] Comuna comuna)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comuna).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(comuna);
        }

        // GET: Comunas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comuna comuna = db.Comuna.Find(id);
            if (comuna == null)
            {
                return HttpNotFound();
            }
            return View(comuna);
        }

        // POST: Comunas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comuna comuna = db.Comuna.Find(id);
            db.Comuna.Remove(comuna);
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
