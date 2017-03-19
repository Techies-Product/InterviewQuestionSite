using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace InterviewSite.CustomActionFilters
{
    public class IsAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)

        {
            if (!object.Equals(HttpContext.Current.Session["UserType"], null))
            {
                if (HttpContext.Current.Session["UserType"].ToString().ToUpper() == "A")
                {
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary { { "controller", "Home" }, { "action", "Index" } });
                }
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                            new RouteValueDictionary{{ "controller", "Home" },{ "action", "Index" }});
            }
            base.OnActionExecuting(filterContext);
        }
    }
}