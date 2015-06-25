
using DolPic.Service.Web.Common;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class ErrorController : CustomController
    {
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 페이지 없음
        /// </summary>
        /// <returns></returns>
        public ActionResult PageNotFound()
        {
            return View();
        }

        /// <summary>
        /// 서버 에러
        /// </summary>
        /// <returns></returns>
        public ActionResult ServerError()
        {
            return View();
        }

        /// <summary>
        /// 인증 에러
        /// </summary>
        /// <returns></returns>
        public ActionResult AuthorizedError()
        {
            return View();
        }
    }
}