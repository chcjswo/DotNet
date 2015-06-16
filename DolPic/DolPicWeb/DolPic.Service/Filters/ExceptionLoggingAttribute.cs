using System;
using System.Web.Mvc;
using log4net;

namespace DolPic.Service.Web.Filters
{
    public class ExceptionLoggingAttribute : FilterAttribute, IExceptionFilter
    {
        protected static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void OnException(ExceptionContext filterContext)
        {
            log.Error("===========================================================================");
            log.ErrorFormat("에러 발생  == {0}", filterContext.Exception.ToString());
            log.Error("===========================================================================");

            filterContext.HttpContext.Response.Cache.SetMaxAge(new TimeSpan(0));
            //filterContext.Result = new RedirectResult("/Common/Error", true);

            filterContext.ExceptionHandled = true;
        }
    }
}