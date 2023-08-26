using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Encuestas.App_Start
{
    public class Session : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["usuario"] == null)
            {
                //FormsAuthentication.SignOut();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                 {
                   { "action", "SesionExists" },
                   { "controller", "Home" },
                   { "Area", "" },
                   { "k", filterContext.HttpContext.Request.RawUrl
                   }
                  });
                return;
            }
        }
    }
}