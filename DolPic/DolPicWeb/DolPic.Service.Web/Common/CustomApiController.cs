using DolPic.Service.Web.Filters;
using log4net;
using System.Web.Http;

namespace DolPic.Service.Web.Common
{
    [ExceptionLogging]
    [NoCache]
    public abstract class CustomApiController : ApiController
    {
        protected static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CustomApiController()
        {
        }
    }
}