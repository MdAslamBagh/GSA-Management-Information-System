using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GSA_Management_Information_System.Models
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        [HandleError]
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                bool authorize = false;
                var controller = httpContext.Request.RequestContext
                    .RouteData.GetRequiredString("controller");
                var action = httpContext.Request.RequestContext
                    .RouteData.GetRequiredString("action");
                //var localPath = httpContext.Request.UrlReferrer.LocalPath;
                // feed the roles here

                var controllerWithAction = controller.ToLower() + "," + action.ToLower();
                //Roles = string.Join(",", _rolesProvider.Get(controller, action));
                //httpContext.Session["shadasku"] = Roles;
                var ob = (List<SubMenuInformation>)httpContext.Session["Page"];

                //var result = ob.Where(kvp => kvp.ControllerName.ToLower() == controller.ToLower() && kvp.ActionName.ToLower() == action.ToLower()).ToList();
                var result = false;
                foreach (var o in ob)
                {
                    string nnn = o.Controller_Name.ToLower() + "," + o.Action_Name.ToLower();
                    if (nnn == controllerWithAction)
                    {
                        result = true;
                        break;
                    }
                }

                if (result)
                {
                    authorize = true;
                }

                return authorize;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
           // string[] values = { };
            //var localPath = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath; //or LocalPath
            //values = localPath.Split('/');
            //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = values[1], action = values[2], msg = "Unauthorize to View This Page" }));
            //filterContext.Result = new HttpUnauthorizedResult("Unauthorized");
            //var localPath = filterContext.HttpContext.Request.UrlReferrer.AbsolutePath;
            //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login", returnUrl= (string)localPath }));
            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Account", action = "Login" }));

        }
    }
}