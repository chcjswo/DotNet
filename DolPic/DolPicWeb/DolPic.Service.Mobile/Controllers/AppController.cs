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
        // 이미지 리스트 사이즈
        private readonly short _nImageListSize;
        // 바로가기 리스트 사이즈
        private readonly int _nGotoListSize;
        // DAO
        private readonly IDolPicService _service;

        /// <summary>
        /// 생성자
        /// </summary>
        public AppController()
        {
            _nImageListSize = 30;
            _nGotoListSize = 5;

            _service = new DolPicService();
        }

        #region 화면 관련

        /// <summary>
        /// 돌픽 메인 화면
        /// </summary>
        /// <returns></returns>
        public ActionResult Main(string id, int? page)
        {
            ViewBag.User = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            var nCurPage = page ?? 1;

            DolPicVo entity = new DolPicVo();
            entity.HashTag = string.IsNullOrEmpty(id) || CommonVariable.ALL_IMAGE.Equals(id) ? "" : id;
            entity.CurPage = nCurPage;
            entity.PageListSize = _nImageListSize;

            ViewBag.DataList = _service.GetMainImageList(entity);
            ViewBag.HashTag = id;
            ViewBag.CurPage = nCurPage;
            ViewBag.PageGotoList = CommonUtil.GetGotoPageList(nCurPage, entity.TotalCnt, _nImageListSize, _nGotoListSize);
            ViewBag.FbImg = CommonVariable.FB_DEFAULT_IMG;

            return View();
        }

        /// <summary>
        /// 유저 즐겨찾기 리스트 화면
        /// </summary>
        /// <returns></returns>
        public ActionResult BookmarkList(string id, int? page)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;
            var nCurPage = page ?? 1;

            DolPicVo entity = new DolPicVo();
            entity.HashTag = string.IsNullOrEmpty(id) || CommonVariable.ALL_IMAGE.Equals(id) ? "" : id;
            entity.CurPage = nCurPage;
            entity.PageListSize = _nImageListSize;
            entity.UserId = UserId;

            ViewBag.DataList = _service.GetBookmarkImageList(entity);
            ViewBag.HashTag = id;
            ViewBag.CurPage = nCurPage;
            ViewBag.PageGotoList = CommonUtil.GetGotoPageList(nCurPage, entity.TotalCnt, _nImageListSize, _nGotoListSize);
            ViewBag.FbImg = CommonVariable.FB_DEFAULT_IMG;

            return View();
        }

        /// <summary>
        /// 즐겨찾기 리스트
        /// </summary>
        /// <param name="CurTag">현재 태그 이름</param>
        /// <returns></returns>
        public ActionResult FavoriteBar(string CurTag)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;
            ViewBag.DataList = _service.GetFavoriteList(UserId);
            ViewBag.CurTag = CurTag;

            return View();
        }

        /// <summary>
        /// 이미지 보기 화면
        /// </summary>
        /// <param name="ImgNo">고유번호</param>
        /// <param name="HahTag">해쉬 태그</param>
        /// <param name="Page">현재 페이지</param>
        /// <returns></returns>
        public ActionResult PicView(int ImgNo, string HashTag, int Page)
        {
            HashTag = CommonVariable.ALL_IMAGE.Equals(HashTag) ? "" : HashTag;
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;
            ViewBag.HashTag = HashTag;
            ViewBag.CurPage = Page;
            ViewBag.ImgNo = ImgNo;

            // 이미지 조회
            DolPicPo po = _service.GetPicView(ImgNo, UserId, HashTag);

            ViewBag.FbImg = po.ImageSrc;
            ViewBag.FbUrl = string.Format("{0}/Pics/PicView/{1}/{2}/{3}", Domains.WebDomain, ImgNo, po.HashTag, Page);

            return View(po);
        }

        /// <summary>
        /// 즐겨찾기 이미지 보기 화면
        /// </summary>
        /// <param name="ImgNo">고유번호</param>
        /// <param name="HahTag">해쉬 태그</param>
        /// <param name="Page">현재 페이지</param>
        /// <returns></returns>
        public ActionResult BookmarkPicView(int ImgNo, string HashTag, int Page)
        {
            HashTag = CommonVariable.ALL_IMAGE.Equals(HashTag) ? "" : HashTag;
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;
            ViewBag.HashTag = HashTag;
            ViewBag.CurPage = Page;
            ViewBag.ImgNo = ImgNo;

            // 이미지 조회
            DolPicPo po = _service.GetBookmarkPicView(ImgNo, UserId, HashTag);

            ViewBag.FbImg = po.ImageSrc;
            ViewBag.FbUrl = string.Format("{0}/Pics/PicView/{1}/{2}/{3}", Domains.WebDomain, ImgNo, po.HashTag, Page);

            return View(po);
        }

        /// <summary>
        /// 초성 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult InitialList()
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;

            // 초성 리스트 조회
            ViewBag.DataList = _service.GetInitialList(UserId, string.Empty);

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

        /// <summary>
        /// 로그인폼
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIn(UserPo model)
        {
            if (Request.UrlReferrer == null)
                model.ReferUrl = "/";
            else
                model.ReferUrl = Request.UrlReferrer.ToString();

            return View(model);
        }

        /// <summary>
        /// 추천 이미지 리스트
        /// </summary>
        /// <param name="ImgNo">고유번호</param>
        /// <param name="HahTag">해쉬 태그</param>
        /// <param name="CurPage">현재 페이지</param>
        /// <returns></returns>
        public ActionResult RecommPicList(int ImgNo, string HashTag, int CurPage)
        {
            // 추천 이미지 리스트 조회
            ViewBag.DataList = _service.RecommImgList(ImgNo);
            ViewBag.HashTag = HashTag;
            ViewBag.CurPage = CurPage;

            return View();
        }

        #endregion
    }

}
