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
            _nImageListSize = 30;
            _nGotoListSize = 5;

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
        public ActionResult Main(string id, int? page)
        {
            ViewBag.User = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
            var nCurPage = page ?? 1;

            DolPicVo entity = new DolPicVo();
            entity.HashTag = string.IsNullOrEmpty(id) || CommonVariable.ALL_IMAGE.Equals(id) ? "" : id;
            entity.CurPage = nCurPage;
            entity.PageListSize = _nImageListSize;

            ViewBag.DataList = _service.GetMainImageList(entity);
            ViewBag.HashTag = id;
            ViewBag.CurPage = nCurPage;
            ViewBag.PageGotoList = CommonUtil.GetGotoPageList(nCurPage, entity.TotalCnt, _nImageListSize, _nGotoListSize);

            return View();
        }

        /// <summary>
        /// 즐겨찾기 리스트 
        /// </summary>
        /// <returns></returns>
        public ActionResult FavoriteBar()
        {
            var UserId = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;
            ViewBag.DataList = _service.GetFavoriteList(UserId);

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
            var UserId = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
            ViewBag.User = UserId;
            ViewBag.HashTag = HashTag;
            ViewBag.CurPage = Page;

            // 이미지 조회
            DolPicPo po = _service.GetPicView(ImgNo, UserId, HashTag);

            return View(po);
        }

        /// <summary>
        /// 초성 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult InitialList()
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
            DolPicPo po = _service.GetPicView(ImgNo, DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME), HashTag);

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
            var UserId = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
            DolPicPo po = new DolPicPo();

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
            var UserId = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
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
            var UserId = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
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
            var UserId = DolPicCookie.CookieRead(this.HttpContext, CommonVariable.COOKIE_NAME);
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
        #endregion
    }
}
