using DolPic.Service.Mobile.Filters;
using log4net;
using System.Web.Mvc;

namespace DolPic.Service.Mobile.Common
{
    [ExceptionLogging]
    [NoCache]
    public abstract class CustomController : Controller
    {
        protected static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CustomController()
        {
        }
    }
}