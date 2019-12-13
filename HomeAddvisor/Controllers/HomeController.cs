using HomeAddvisor.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace HomeAddvisor.Controllers
{
    public class HomeController : Controller
    {
        private HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1();

        public ActionResult Index()
        {
            ViewBag.ListaProfesional = db.Profesional.ToList();
            return View();
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