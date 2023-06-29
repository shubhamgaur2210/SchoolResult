using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SchoolResultProject2.Models;

namespace SchoolResultProject2.Controllers
{
    public class BaseController : Controller
    {
        [HttpGet]
        public ActionResult GetSessionUser()
        {
            return Json((User)Session["User"], JsonRequestBehavior.AllowGet);
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;

            if (Session["User"] != null && action == "Login")
            {
                Session.Abandon();
            }

            if (controller != "Account" && action != "Logout" && action != "GetSessionUser")
            {
                if (Session["User"] != null)
                {
                    User user = (User)Session["User"];

                    if (controller != user.Role)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                        {
                            {"controller", user.Role },
                            {"action", "Index" }
                        });
                    }
                }
                else
                {
                    if (controller != "Account" && action != "Login")
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                    {
                        {"controller", "Account" },
                        {"action", "Login" }
                    });
                    }
                }
            }
        }
    }
}