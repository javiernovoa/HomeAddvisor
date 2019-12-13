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
    public class ServiciosController : Controller
    {
        private HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1();

        // GET: Servicios
        public ActionResult Index()
        {
            var servicio = db.Servicio.Include(s => s.Cliente).Include(s => s.Comuna).Include(s => s.Deuda1).Include(s => s.Profesional).Include(s => s.Region);
            return View(servicio.ToList());
        }

        // GET: Servicios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // GET: Servicios/Create
        public ActionResult Create()
        {
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Rut_Cliente");
            ViewBag.Id_ComunaS = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna");
            ViewBag.Id_Deuda = new SelectList(db.Deuda, "Id_Deuda", "Monto_Deuda");
            ViewBag.Id_Profesional = new SelectList(db.Profesional, "Id_Profesional", "Rut_Profesional");
            ViewBag.Id_RegionS = new SelectList(db.Region, "Id_Region", "Nombre_Region");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Servicio,Id_Cliente,Id_Profesional,Id_Deuda,Descripcion_Servicio,Total_Servicio,Fecha_Servicio,Direccion,Clasificacion,Id_ComunaS,Id_RegionS")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Rut_Cliente", servicio.Id_Cliente);
            ViewBag.Id_ComunaS = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", servicio.Id_ComunaS);
            ViewBag.Id_Deuda = new SelectList(db.Deuda, "Id_Deuda", "Monto_Deuda", servicio.Id_Deuda);
            ViewBag.Id_Profesional = new SelectList(db.Profesional, "Id_Profesional", "Rut_Profesional", servicio.Id_Profesional);
            ViewBag.Id_RegionS = new SelectList(db.Region, "Id_Region", "Nombre_Region", servicio.Id_RegionS);
            return View(servicio);
        }

        // GET: Servicios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Rut_Cliente", servicio.Id_Cliente);
            ViewBag.Id_ComunaS = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", servicio.Id_ComunaS);
            ViewBag.Id_Deuda = new SelectList(db.Deuda, "Id_Deuda", "Monto_Deuda", servicio.Id_Deuda);
            ViewBag.Id_Profesional = new SelectList(db.Profesional, "Id_Profesional", "Rut_Profesional", servicio.Id_Profesional);
            ViewBag.Id_RegionS = new SelectList(db.Region, "Id_Region", "Nombre_Region", servicio.Id_RegionS);
            return View(servicio);
        }

        // POST: Servicios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Servicio,Id_Cliente,Id_Profesional,Id_Deuda,Descripcion_Servicio,Total_Servicio,Fecha_Servicio,Direccion,Clasificacion,Id_ComunaS,Id_RegionS")] Servicio servicio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(servicio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Rut_Cliente", servicio.Id_Cliente);
            ViewBag.Id_ComunaS = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", servicio.Id_ComunaS);
            ViewBag.Id_Deuda = new SelectList(db.Deuda, "Id_Deuda", "Monto_Deuda", servicio.Id_Deuda);
            ViewBag.Id_Profesional = new SelectList(db.Profesional, "Id_Profesional", "Rut_Profesional", servicio.Id_Profesional);
            ViewBag.Id_RegionS = new SelectList(db.Region, "Id_Region", "Nombre_Region", servicio.Id_RegionS);
            return View(servicio);
        }

        // GET: Servicios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Servicio servicio = db.Servicio.Find(id);
            if (servicio == null)
            {
                return HttpNotFound();
            }
            return View(servicio);
        }

        // POST: Servicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Servicio servicio = db.Servicio.Find(id);
            db.Servicio.Remove(servicio);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CreateS()
        {
            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Rut_Cliente");
            ViewBag.Id_ComunaS = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna");
            ViewBag.Id_Deuda = new SelectList(db.Deuda, "Id_Deuda", "Monto_Deuda");
            ViewBag.Id_Profesional = new SelectList(db.Profesional, "Id_Profesional", "Rut_Profesional");
            ViewBag.Id_RegionS = new SelectList(db.Region, "Id_Region", "Nombre_Region");
            return View();
        }

        // POST: Servicios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateS([Bind(Include = "Id_Servicio,Id_Cliente,Id_Profesional,Id_Deuda,Descripcion_Servicio,Total_Servicio,Fecha_Servicio,Direccion,Clasificacion,Id_ComunaS,Id_RegionS")] Servicio servicio)
        {

            if (ModelState.IsValid)
            {
                db.Servicio.Add(servicio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Cliente = new SelectList(db.Cliente, "Id_Cliente", "Rut_Cliente", servicio.Id_Cliente);
            ViewBag.Id_ComunaS = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", servicio.Id_ComunaS);
            ViewBag.Id_Deuda = new SelectList(db.Deuda, "Id_Deuda", "Monto_Deuda", servicio.Id_Deuda);
            ViewBag.Id_Profesional = new SelectList(db.Profesional, "Id_Profesional", "Rut_Profesional", servicio.Id_Profesional);
            ViewBag.Id_RegionS = new SelectList(db.Region, "Id_Region", "Nombre_Region", servicio.Id_RegionS);
            return View(servicio);
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
