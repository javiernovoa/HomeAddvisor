using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HomeAddvisor.DB;

namespace HomeAddvisor.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Enter(string user, string pass)
        {
            try
            {
                using (HOMEADDVISOR_DBEntities1 db = new HOMEADDVISOR_DBEntities1())
                {
                    var lst = from d in db.Administrador
                              where d.Rut_Adminsitrador == user && d.Password == pass //&& d.Bloqueado == false
                              select d;
                    if (lst.Count() > 0)
                    {
                        Administrador oUser = lst.First();
                        Session["Admin"] = oUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Usuario invalido :(");
                    }
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :( " + ex.Message);
            }

        }
    }
}