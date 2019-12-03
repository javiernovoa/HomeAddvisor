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
    public class DeudasController : Controller
    {
        private HOMEADDVISOR_DBEntities db = new HOMEADDVISOR_DBEntities();

        // GET: Deudas
        public ActionResult Index()
        {
            var deuda = db.Deuda.Include(d => d.Servicio);
            return View(deuda.ToList());
        }

        // GET: Deudas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deuda deuda = db.Deuda.Find(id);
            if (deuda == null)
            {
                return HttpNotFound();
            }
            return View(deuda);
        }

        // GET: Deudas/Create
        public ActionResult Create()
        {
            ViewBag.Id_Servicio = new SelectList(db.Servicio, "Id_Servicio", "Descripcion_Servicio");
            return View();
        }

        // POST: Deudas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Deuda,Id_Servicio,Monto_Deuda,Porcentaje_Deuda")] Deuda deuda)
        {
            if (ModelState.IsValid)
            {
                db.Deuda.Add(deuda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Servicio = new SelectList(db.Servicio, "Id_Servicio", "Descripcion_Servicio", deuda.Id_Servicio);
            return View(deuda);
        }

        // GET: Deudas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deuda deuda = db.Deuda.Find(id);
            if (deuda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Servicio = new SelectList(db.Servicio, "Id_Servicio", "Descripcion_Servicio", deuda.Id_Servicio);
            return View(deuda);
        }

        // POST: Deudas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Deuda,Id_Servicio,Monto_Deuda,Porcentaje_Deuda")] Deuda deuda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deuda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Servicio = new SelectList(db.Servicio, "Id_Servicio", "Descripcion_Servicio", deuda.Id_Servicio);
            return View(deuda);
        }

        // GET: Deudas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Deuda deuda = db.Deuda.Find(id);
            if (deuda == null)
            {
                return HttpNotFound();
            }
            return View(deuda);
        }

        // POST: Deudas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Deuda deuda = db.Deuda.Find(id);
            db.Deuda.Remove(deuda);
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
