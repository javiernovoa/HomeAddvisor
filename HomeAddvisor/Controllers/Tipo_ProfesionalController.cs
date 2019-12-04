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
    public class Tipo_ProfesionalController : Controller
    {
        private HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1();

        // GET: Tipo_Profesional
        public ActionResult Index()
        {
            var tipo_Profesional = db.Tipo_Profesional.Include(t => t.Areas);
            return View(tipo_Profesional.ToList());
        }

        // GET: Tipo_Profesional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Profesional tipo_Profesional = db.Tipo_Profesional.Find(id);
            if (tipo_Profesional == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Profesional);
        }

        // GET: Tipo_Profesional/Create
        public ActionResult Create()
        {
            ViewBag.Id_Area = new SelectList(db.Areas, "Id_Area", "Nombre_Area");
            return View();
        }

        // POST: Tipo_Profesional/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Codigo_Profesional,Id_Tipo,Nombre_Tipo,Id_Area")] Tipo_Profesional tipo_Profesional)
        {
            if (ModelState.IsValid)
            {
                db.Tipo_Profesional.Add(tipo_Profesional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Area = new SelectList(db.Areas, "Id_Area", "Nombre_Area", tipo_Profesional.Id_Area);
            return View(tipo_Profesional);
        }

        // GET: Tipo_Profesional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Profesional tipo_Profesional = db.Tipo_Profesional.Find(id);
            if (tipo_Profesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Area = new SelectList(db.Areas, "Id_Area", "Nombre_Area", tipo_Profesional.Id_Area);
            return View(tipo_Profesional);
        }

        // POST: Tipo_Profesional/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Codigo_Profesional,Id_Tipo,Nombre_Tipo,Id_Area")] Tipo_Profesional tipo_Profesional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipo_Profesional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Area = new SelectList(db.Areas, "Id_Area", "Nombre_Area", tipo_Profesional.Id_Area);
            return View(tipo_Profesional);
        }

        // GET: Tipo_Profesional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Profesional tipo_Profesional = db.Tipo_Profesional.Find(id);
            if (tipo_Profesional == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Profesional);
        }

        // POST: Tipo_Profesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tipo_Profesional tipo_Profesional = db.Tipo_Profesional.Find(id);
            db.Tipo_Profesional.Remove(tipo_Profesional);
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
