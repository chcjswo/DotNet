using DolPic.Biz.DolPicService;
using DolPic.Common;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using Newtonsoft.Json;
using System.Web.Mvc;
using DolPic.Service.Web.Filters;
using DolPic.Service.Web.Models;
using System;
using DolPic.Biz.DolPicAdmin;
using System.Collections.Generic;
using System.Net;
using System.IO;
using DolPic.Data.Daos;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;

namespace DolPic.Service.Web.Controllers
{
    [DeviceCheck]
    public class PicsController : CustomController
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
        public PicsController()
        {
            _nImageListSize = 50;
            _nGotoListSize = 10;

            _service = new DolPicService();
        }

        public ActionResult Index()
        {
            return RedirectToAction("Main");
        }

        #region 화면 관련

        /// <summary>
        /// 돌픽 메인 화면
        /// </summary>
        /// <returns></returns>
        [OutputCache(Duration = 600)]
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
        [OutputCache(Duration = 600)]
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
        [OutputCache(Duration = 600)]
        public ActionResult HotDolPicList()
        {
            // 핫돌픽 리스트 조회
            ViewBag.DataList = _service.GetHotDolPicList();

            return View();
        }

        /// <summary>
        /// 추천 이미지 리스트
        /// </summary>
        /// <param name="ImgNo">고유번호</param>
        /// <param name="HahTag">해쉬 태그</param>
        /// <param name="CurPage">현재 페이지</param>
        /// <returns></returns>
        [OutputCache(Duration = 3600)]
        public ActionResult RecommPicList(int ImgNo, string HashTag, int CurPage)
        {
            // 추천 이미지 리스트 조회
            ViewBag.DataList = _service.RecommImgList(ImgNo);
            ViewBag.HashTag = HashTag;
            ViewBag.CurPage = CurPage;

            return View();
        }

        #endregion

        #region Ajax 관련
        /// <summary>
        /// 메인 이미지 리스트 Ajax
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImageList(int CurPage, string HashTag)
        {
            HashTag = CommonVariable.ALL_IMAGE.Equals(HashTag) ? "" : HashTag;
            DolPicVo entity = new DolPicVo();
            entity.HashTag = HashTag ?? "";
            entity.CurPage = CurPage;
            entity.PageListSize = _nImageListSize;

            PageList pageList = new PageList();
            pageList.ImageList = _service.GetMainImageList(entity);
            pageList.PageGotoList = CommonUtil.GetGotoPageList(CurPage, entity.TotalCnt, _nImageListSize, _nGotoListSize);
            ViewBag.CurPage = CurPage;

            return Json(JsonConvert.SerializeObject(pageList));
        }

        /// <summary>
        /// 즐겨찾기 이미지 리스트 Ajax
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult BookmarkImageList(int CurPage, string HashTag)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);

            HashTag = CommonVariable.ALL_IMAGE.Equals(HashTag) ? "" : HashTag;
            DolPicVo entity = new DolPicVo();
            entity.HashTag = HashTag ?? "";
            entity.CurPage = CurPage;
            entity.PageListSize = _nImageListSize;
            entity.UserId = UserId;

            PageList pageList = new PageList();
            pageList.ImageList = _service.GetBookmarkImageList(entity);
            pageList.PageGotoList = CommonUtil.GetGotoPageList(CurPage, entity.TotalCnt, _nImageListSize, _nGotoListSize);
            ViewBag.CurPage = CurPage;

            return Json(JsonConvert.SerializeObject(pageList));
        }

        /// <summary>
        /// 이미지 보기 Ajax
        /// </summary>
        /// <param name="ImgNo">고유번호</param>
        /// <param name="HahTag">해쉬 태그</param>
        /// <param name="Page">현재 페이지</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImageView(int ImgNo, string HashTag, int Page)
        {
            HashTag = CommonVariable.ALL_IMAGE.Equals(HashTag) ? "" : HashTag;
            ViewBag.HashTag = HashTag;

            // 이미지 조회
            DolPicPo po = _service.GetPicView(ImgNo, DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME), HashTag);

            return Json(JsonConvert.SerializeObject(po));
        }

        /// <summary>
        /// 이미지 좋아요 Ajax
        /// </summary>
        /// <param name="Seq">고유번호</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PicLikeInsert(int Seq)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            DolPicPo po = new DolPicPo();

            // Ajax Call 체크
            if (!Request.IsAjaxRequest())
            {
                po.RetCode = (int)e_RetCode.refer_error;
                po.RetMsg = "잘 못된 접근입니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 로그인 체크
            if (string.IsNullOrEmpty(UserId))
            {
                po.RetCode = (int)e_RetCode.discord;
                po.RetMsg = "로그인후 사용 가능합니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 이미지 좋아요 처리
            po = _service.PicLike(Seq, UserId);

            switch (po.RetCode)
            {
                // 이미 등록된 경우
                case (int)e_RetCode.has:
                    po.RetMsg = "이미 좋아요를 하셨습니다.";
                    break;

                // DB에러
                case (int)e_RetCode.db_error:
                    po.RetMsg = "에러가 발생했습니다. 다시 한번 시도해주세요.";
                    break;
            }

            return Json(JsonConvert.SerializeObject(po));
        }

        /// <summary>
        /// 즐겨찾기 추가 Ajax
        /// </summary>
        /// <param name="TagNo">고유번호</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FavoriteInsert(int TagNo)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            DolPicPo po = new DolPicPo();

            // 로그인 체크
            if (string.IsNullOrEmpty(UserId))
            {
                po.RetCode = (int)e_RetCode.discord;
                po.RetMsg = "로그인후 사용 가능합니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 즐겨찾기 입력 처리
            po.RetCode = _service.FavoriteInsert(TagNo, UserId);

            switch (po.RetCode)
            {
                // 이미 등록된 경우
                case (int)e_RetCode.has:
                    po.RetMsg = "이미 즐겨찾기를 하셨습니다.";
                    break;

                // DB에러
                case (int)e_RetCode.db_error:
                    po.RetMsg = "에러가 발생했습니다. 다시 한번 시도해주세요.";
                    break;
            }

            return Json(JsonConvert.SerializeObject(po));
        }

        /// <summary>
        /// 즐겨찾기 삭제 Ajax
        /// </summary>
        /// <param name="TagNo">고유번호</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult FavoriteDelete(int TagNo)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            DolPicPo po = new DolPicPo();

            // 로그인 체크
            if (string.IsNullOrEmpty(UserId))
            {
                po.RetCode = (int)e_RetCode.discord;
                po.RetMsg = "로그인후 사용 가능합니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 즐겨찾기 삭제 처리
            po.RetCode = _service.FavoriteDelete(TagNo, UserId);

            switch (po.RetCode)
            {
                // 이미 등록된 경우
                case (int)e_RetCode.has:
                    po.RetMsg = "이미 즐겨찾기를 하셨습니다.";
                    break;

                // DB에러
                case (int)e_RetCode.db_error:
                    po.RetMsg = "에러가 발생했습니다. 다시 한번 시도해주세요.";
                    break;
            }

            return Json(JsonConvert.SerializeObject(po));
        }

        /// <summary>
        /// 신고하기 Ajax
        /// </summary>
        /// <param name="ImgNo">이미지 고유번호</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImgReportInsert(int ImgNo)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);
            DolPicPo po = new DolPicPo();

            // 로그인 체크
            if (string.IsNullOrEmpty(UserId))
            {
                po.RetCode = (int)e_RetCode.discord;
                po.RetMsg = "로그인후 사용 가능합니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 신고하기 입력 처리
            po.RetCode = _service.ImgReportInsert(ImgNo, UserId);

            switch (po.RetCode)
            {
                // 등록 성공
                case (int)e_RetCode.success:
                    po.RetMsg = "신고가 등록 됐습니다.";
                    break;

                // 이미 등록된 경우
                case (int)e_RetCode.has:
                    po.RetMsg = "이미 신고를 하셨습니다.";
                    break;

                // DB에러
                case (int)e_RetCode.db_error:
                    po.RetMsg = "에러가 발생했습니다. 다시 한번 시도해주세요.";
                    break;
            }

            return Json(JsonConvert.SerializeObject(po));
        }

        /// <summary>
        /// 검색 아이돌 리스트 Ajax
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult InitialSearchList(string SearchDol)
        {
            var UserId = DolPicCookie.CookieRead(this.Request, CommonVariable.COOKIE_NAME);

            // 초성 리스트 조회
            var list = _service.GetInitialList(UserId, SearchDol);

            StringBuilder sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.Append("<div class='dolpic_lbox'>");
                sb.Append("<div class='dolpic_ltag'>");
                sb.Append("<img src = '/images/sns_instagram.png' width='12' height='12' alt='Instagram'>");
                sb.Append("<img src = '/images/sns_twitter.png' width='12' height='12' alt='Twitter'>");
                sb.Append("</div>");
                sb.AppendFormat("<div class='dolpic_limg' style='background:url({0:thumb}) center center no-repeat;background-size:cover' onclick=\"location.href='/Pics/Main/{1}';\"></div>",
                    item.ImageSrc, item.HashTag);
                sb.AppendFormat("<div class='dolpic_lname' onclick=\"location.href='/Pics/Main/{0}';\" style='cursor:pointer'>{0}</div>", item.HashTag);
                if (item.Seq == item.FavoriteSeq)
                    sb.AppendFormat("<div id = 'in{0}' class='dolpic_fbtn on' onclick=\'fnFavoriteInsert(\"{0}\", \"{1}\");\'></div>", item.Seq, item.HashTag);
                else
                    sb.AppendFormat("<div id = 'in{0}' class='dolpic_fbtn off' onclick=\'fnFavoriteInsert(\"{0}\", \"{1}\");\'></div>", item.Seq, item.HashTag);
                sb.Append("</div>");
            }

            return Json(JsonConvert.SerializeObject(new { list = sb.ToString() }));
        }
        #endregion

        #region 짤린 이미지 삭제

        /// <summary>
        /// 짤린 이미지 삭제
        /// </summary>
        /// <returns></returns>
        public string DolPicNoImageDelete()
        {
            log.ErrorFormat("DolPicNoImageDelete call ~~~~");
            DeleteEmptyImage();

            return "삭제 완료";
        }

        /// <summary>
        /// 이미지가 짤렸는지 검색하고 짤린 이미지라면 삭제
        /// </summary>
        /// <returns></returns>
        private void DeleteEmptyImage()
        {
            var ImageSrc = "";
            var seq = 0;

            DolPicAdmin dao = new DolPicAdmin();
            var list = dao.GetDolPicAllImageList();

            DolPicVo entity = new DolPicVo();
            AdminDao adminDao = new AdminDao();

            using (var client = new HttpClient())
            {
                foreach (var item in list)
                {
                    ImageSrc = item.ImageSrc;
                    seq = item.Seq;

                    try
                    {
                        client.DefaultRequestHeaders.ExpectContinue = false;
                        var result = client.PostAsync(string.Format("{0}", ImageSrc),
                        new
                        {
                        }, new JsonMediaTypeFormatter()).Result;
                    }
                    catch (Exception ex)
                    {
                        // 짤린 이미지 삭제
                        entity.Seq = seq;
                        adminDao.DolPicNoImageDelete(entity);

                        log.ErrorFormat("no ImageSrc == {0}", ImageSrc);
                        log.ErrorFormat("no seq == {0}", seq);
                        log.ErrorFormat("error == {0}", ex.ToString());
                    }
                }
            }
        }
        #endregion
    }
}
