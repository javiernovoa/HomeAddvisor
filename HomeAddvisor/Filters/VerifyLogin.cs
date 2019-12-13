using HomeAddvisor.Controllers;
using HomeAddvisor.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeAddvisor.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
           //var admin = (Administrador)HttpContext.Current.Session["Admin"];
           //if (admin == null)
            //{
            //  if (filterContext.Controller is LoginController == false)
           //   {
           //       filterContext.HttpContext.Response.Redirect("~/Login/Index");
            // }
                
            //}
            //else
           //{
             // if (filterContext.Controller is LoginController == true)
             //   {
             //     filterContext.HttpContext.Response.Redirect("~/Home/Index");
            // }
           //}
            base.OnActionExecuting(filterContext);

        }
    }

}