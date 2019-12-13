using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using HomeAddvisor.DB;

namespace HomeAddvisor.Controllers
{
    public class ProfesionalsController : Controller
    {
        private HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1();

        // GET: Profesionals
        public ActionResult Index()
        {
            var profesional = db.Profesional.Include(p => p.Comuna).Include(p => p.Tipo_Profesional).Include(p => p.Region);
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
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo");
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region");
            return View();
        }

        // POST: Profesionals/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_Profesional,Rut_Profesional,Nombre_Profesional,ApellidoPa_Profesional,ApellidoMa_Profesional,Domicilio_Profesional,Bloqueado,Email,Password,Telefono,Capacitacion,Imagen,Disponibilidad,Jornada,Codigo_Profesional,Id_RegionP,Id_ComunaP")] Profesional profesional)
        {
            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.ContentLength == 0)
            {
                ModelState.AddModelError("Imagen","Es necesario seleccionar una imagen");
            }
            else
            {
                if (FileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage image = new WebImage(FileBase.InputStream);

                    profesional.Imagen = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen","Es necesario seleccionar una imagen(o el formato no es .jpg)");
                }
                
            }


            //HttpFileCollectionBase ColleccionBase = Request.Files;

           

            if (ModelState.IsValid)
            {
                db.Profesional.Add(profesional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_ComunaP = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", profesional.Id_ComunaP);
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo", profesional.Codigo_Profesional);
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region", profesional.Id_RegionP);
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
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo", profesional.Codigo_Profesional);
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region", profesional.Id_RegionP);
            return View(profesional);
        }

        // POST: Profesionals/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_Profesional,Rut_Profesional,Nombre_Profesional,ApellidoPa_Profesional,ApellidoMa_Profesional,Domicilio_Profesional,Bloqueado,Email,Password,Telefono,Capacitacion,Imagen,Disponibilidad,Jornada,Codigo_Profesional,Id_RegionP,Id_ComunaP")] Profesional profesional)
        {
            //byte[] imagenActual = null;

            Profesional pro = new Profesional();
            HttpPostedFileBase FileBase = Request.Files[0];
            if (FileBase.ContentLength == 0)
            {
                pro = db.Profesional.Find(profesional.Id_Profesional);
                profesional.Imagen = pro.Imagen;
            }
            else
            {
                if (FileBase.FileName.EndsWith(".jpg"))
                {
                    WebImage image = new WebImage(FileBase.InputStream);

                    profesional.Imagen = image.GetBytes();
                }
                else
                {
                    ModelState.AddModelError("Imagen", "Es necesario seleccionar una imagen(o el formato no es .jpg)");
                }
            }
            if (ModelState.IsValid)
            {
                db.Entry(profesional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_ComunaP = new SelectList(db.Comuna, "Id_Comuna", "Nombre_Comuna", profesional.Id_ComunaP);
            ViewBag.Codigo_Profesional = new SelectList(db.Tipo_Profesional, "Codigo_Profesional", "Nombre_Tipo", profesional.Codigo_Profesional);
            ViewBag.Id_RegionP = new SelectList(db.Region, "Id_Region", "Nombre_Region", profesional.Id_RegionP);
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
        public ActionResult getImage(int id)
        {
            Profesional profesional = db.Profesional.Find(id);
            byte[] byteImage = profesional.Imagen;

            MemoryStream memoryStream = new MemoryStream(byteImage);
            Image image = Image.FromStream(memoryStream);

            memoryStream = new MemoryStream();
            image.Save(memoryStream, ImageFormat.Jpeg);
            memoryStream.Position = 0;

            return File(memoryStream,"image/jpg");
        }
    }
}
