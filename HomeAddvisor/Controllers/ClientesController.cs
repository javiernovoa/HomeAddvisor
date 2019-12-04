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
    public class ClientesController : Controller
    {
        private HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1();

        // GET: Clientes
        public ActionResult Index()
        {
            var cliente = db.Cliente.Include(c => c.Comuna).Include(c => c.Region);
            return View(cliente.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.Id_Comuna = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna");
            ViewBag.Id_Region = new SelectList(db.Region, "Id_Region", "Nombre_Region");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Cliente,Rut_Cliente,Nombre_Cliente,ApellidoPa_Cliente,ApellidoMa_Cliente,Domicilio_Cliente,Bloqueado,Email,Password,Telefono,Id_Comuna,Id_Region")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Cliente.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_Comuna = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", cliente.Id_Comuna);
            ViewBag.Id_Region = new SelectList(db.Region, "Id_Region", "Nombre_Region", cliente.Id_Region);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_Comuna = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", cliente.Id_Comuna);
            ViewBag.Id_Region = new SelectList(db.Region, "Id_Region", "Nombre_Region", cliente.Id_Region);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Cliente,Rut_Cliente,Nombre_Cliente,ApellidoPa_Cliente,ApellidoMa_Cliente,Domicilio_Cliente,Bloqueado,Email,Password,Telefono,Id_Comuna,Id_Region")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_Comuna = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", cliente.Id_Comuna);
            ViewBag.Id_Region = new SelectList(db.Region, "Id_Region", "Nombre_Region", cliente.Id_Region);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Cliente.Find(id);
            db.Cliente.Remove(cliente);
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
