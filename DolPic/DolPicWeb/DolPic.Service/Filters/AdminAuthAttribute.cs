using System;
using System.Web.Mvc;
using log4net;
using System.Web;

namespace DolPic.Service.Web.Filters
{
    public class AdminAuthAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpContext.Current.Response.Write("AuthorizeCore");

            return true;  // 권한 체크  True : False
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthorizeCore(filterContext.HttpContext))
            {
            }
            else
            {
            }

            HttpContext.Current.Response.Write("OnAuthorization");
        }
    }
}