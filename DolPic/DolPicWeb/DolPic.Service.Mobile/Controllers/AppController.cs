using DolPic.Biz.DolPicService;
using DolPic.Common;
using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using DolPic.Service.Mobile.Common;
using DolPic.Service.Mobile.Models;
using Newtonsoft.Json;
using System.Text;
using System.Web.Mvc;

namespace DolPic.Service.Mobile.Controllers
{
    /// <summary>
    /// 앱에서 사용 할 클래스
    /// </summary>
    public class AppController : CustomController
    {
        // DAO
        private readonly IDolPicService _service;

        /// <summary>
        /// 생성자
        /// </summary>
        public AppController()
        {
            _service = new DolPicService();
        }

        #region 화면 관련

        /// <summary>
        /// 초성 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult AppInitialList()
        {
            var UserId = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;

            // 초성 리스트 조회
            ViewBag.DataList = _service.GetInitialList(UserId);

            return View();
        }

        /// <summary>
        /// 핫돌픽 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult HotDolPicList()
        {
            // 핫돌픽 리스트 조회
            ViewBag.DataList = _service.GetHotDolPicList();

            return View();
        }

        #endregion
    }

}
