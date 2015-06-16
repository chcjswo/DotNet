using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DolPic.Service.Web.Filters
{
    public class DeviceCheckAttribute
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetMaxAge(new TimeSpan(0));

            //if (HttpContext.Current.Request.Browser.IsMobileDevice)
            //{
            //    //log.ErrorFormat("Domains.MobileDomain == {0}", Domains.MobileDomain);
            //    //log.ErrorFormat("sReUrl == {0}", filterContext.HttpContext.Request.QueryString);
            //    filterContext.Result = new RedirectResult(string.Format("{2}/Games/{0}/{1}",
            //        filterContext.RouteData.Values["controller"].ToString(), filterContext.RouteData.Values["action"].ToString(), Domains.MobileDomain));
            //}
        }
    }
}