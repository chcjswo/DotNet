using DolPic.Common;
using System;
using System.Web;
using System.Web.Mvc;

namespace DolPic.Service.Web.Filters
{
    public class DeviceCheckAttribute : FilterAttribute, IAuthorizationFilter
    {
        //protected static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void OnAuthorization(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetMaxAge(new TimeSpan(0));

            if (HttpContext.Current.Request.Browser.IsMobileDevice)
            {
                //log.ErrorFormat("Domains.MobileDomain == {0}", Domains.MobileDomain);
                //log.ErrorFormat("sReUrl == {0}", filterContext.HttpContext.Request.Url.PathAndQuery);

                filterContext.Result = new RedirectResult(string.Format("{0}/{1}",
                                                                        Domains.MobileDomain,
                                                                        filterContext.HttpContext.Request.Url.PathAndQuery));
            }
        }
    }
}