using HomeAddvisor.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAddvisor.Controllers
{
    public class RegistroClienteController : Controller
    {

        private HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1();
        // GET: RegistroCliente
        public ActionResult Index()
        {
            return View();
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