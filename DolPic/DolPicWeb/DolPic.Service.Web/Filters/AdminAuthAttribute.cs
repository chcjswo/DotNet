using System;
using System.Web.Mvc;
using System.Web;
using DolPic.Common;

namespace DolPic.Service.Web.Filters
{
    public class AdminAuthAttribute : AuthorizeAttribute
    {
        public new UserRole Roles;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (httpContext == null)
                throw new ArgumentNullException("httpContext");

            if (null == httpContext.Session["UserRole"]
                || "" == httpContext.Session["UserRole"].ToString())
                return false;

            UserRole role
                = (UserRole)Convert.ToInt32(httpContext.Session["UserRole"]);

            if (Roles != 0 && ((Roles & role) != role))
                return false;

            if ((int)UserRole.admin != Convert.ToInt32(httpContext.Session["UserRole"]))
                return false;

            return true;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!AuthorizeCore(filterContext.HttpContext))
            {
                filterContext.Result = new RedirectResult("~/Error/AuthorizedError");
            }

        }
    }

}