using HomeAddvisor.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAddvisor.Controllers
{
    public class LoginController : Controller
    {
        private HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1();
        // GET: Login
        public ActionResult Index()
        {
            return View();
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