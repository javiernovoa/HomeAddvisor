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
    public class ProfesionalsController : Controller
    {
        private HOMEADDVISOR_DBEntities db = new HOMEADDVISOR_DBEntities();

        // GET: Profesionals
        public ActionResult Index()
        {
            var profesional = db.Profesional.Include(p => p.Comuna).Include(p => p.Region).Include(p => p.Tipo_Profesional);
            return View(profesional.ToList());
        }

        // GET: Profesionals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesional.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // GET: Profesionals/Create
        public ActionResult Create()
        {
            ViewBag.Id_ComunaP = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna");
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region");
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo");
            return View();
        }

        // POST: Profesionals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Profesional,Rut_Profesional,Nombre_Profesional,ApellidoPa_Profesional,ApellidoMa_Profesional,Domicilio_Profesional,Bloqueado,Email,Password,Telefono,Capacitacion,Imagen,Disponibilidad,Jornada,Codigo_Profesional,Id_RegionP,Id_ComunaP")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                db.Profesional.Add(profesional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_ComunaP = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", profesional.Id_ComunaP);
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region", profesional.Id_RegionP);
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo", profesional.Codigo_Profesional);
            return View(profesional);
        }

        // GET: Profesionals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesional.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_ComunaP = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", profesional.Id_ComunaP);
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region", profesional.Id_RegionP);
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo", profesional.Codigo_Profesional);
            return View(profesional);
        }

        // POST: Profesionals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Profesional,Rut_Profesional,Nombre_Profesional,ApellidoPa_Profesional,ApellidoMa_Profesional,Domicilio_Profesional,Bloqueado,Email,Password,Telefono,Capacitacion,Imagen,Disponibilidad,Jornada,Codigo_Profesional,Id_RegionP,Id_ComunaP")] Profesional profesional)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_ComunaP = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", profesional.Id_ComunaP);
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region", profesional.Id_RegionP);
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo", profesional.Codigo_Profesional);
            return View(profesional);
        }

        // GET: Profesionals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesional.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // POST: Profesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesional profesional = db.Profesional.Find(id);
            db.Profesional.Remove(profesional);
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
