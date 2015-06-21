using DolPic.Biz.DolPicService;
using DolPic.Common;
using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class PicsController : CustomController
    {
        private const string COOKIE_NAME = "user";
        // 이미지 리스트 사이즈
        private readonly short _nImageListSize;
        // 바로가기 리스트 사이즈
        private readonly int _nGotoListSize;
        // DAO
        private readonly IDolPicService _dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public PicsController()
        {
            _nImageListSize = 50;
            _nGotoListSize = 10;

            _dao = new DolPicService();
        }

        //
        // GET: /Piscs/
        //public ActionResult Index()
        //{
        //    return RedirectToAction("Main");
        //}
        public string Index()
        {
            return Server.MapPath("~");
        }

        #region 화면 관련
        /// <summary>
        /// 돌픽 메인
        /// </summary>
        /// <returns></returns>
        //[Authorize(Roles = "Administrator")] 
        public ActionResult Main(string id)
        {
            ViewBag.User = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);

            DolPicVo entity = new DolPicVo();
            entity.HashTag = id ?? "";
            entity.CurPage = 1;
            entity.PageListSize = _nImageListSize;

            ViewBag.DataList = _dao.GetMainImageList(entity);
            ViewBag.HashTag = id;
            ViewBag.PageGotoList = GetGotoPageList(1, entity.TotalCnt, _nImageListSize, _nGotoListSize);

            return View();
        }

        /// <summary>
        /// 즐겨찾기 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult FavoriteBar()
        {
            var UserId = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);
            ViewBag.User = UserId;
            ViewBag.DataList = _dao.GetFavoriteList(UserId);

            return View();
        }

        /// <summary>
        /// 이미지 보기
        /// </summary>
        /// <param name="ImgNo">고유번호</param>
        /// <param name="HahTag">해쉬 태그</param>
        /// <returns></returns>
        public ActionResult PicView(int ImgNo, string HashTag)
        {
            var UserId = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);
            ViewBag.User = UserId;
            ViewBag.HashTag = HashTag;

            // 이미지 조회
            DolPicPo po = _dao.GetPicView(ImgNo, UserId, HashTag);

            return View(po);
        }

        /// <summary>
        /// 초성 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult InitialList()
        {
            var UserId = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);
            ViewBag.User = UserId;

            // 초성 리스트 조회
            ViewBag.DataList = _dao.GetInitialList(UserId);

            return View();
        }

        /// <summary>
        /// 핫돌픽 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult HotDolPicList()
        {
            // 핫돌픽 리스트 조회
            ViewBag.DataList = _dao.GetHotDolPicList();

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
            DolPicVo entity = new DolPicVo();
            entity.HashTag = HashTag ?? "";
            entity.CurPage = CurPage;
            entity.PageListSize = _nImageListSize;

            ReturnResult result = new ReturnResult();
            result.ImageList = _dao.GetMainImageList(entity);
            result.PageGotoList = GetGotoPageList(CurPage, entity.TotalCnt, _nImageListSize, _nGotoListSize);

            return Json(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 이미지 보기 Ajax
        /// </summary>
        /// <param name="ImgNo">고유번호</param>
        /// <param name="HahTag">해쉬 태그</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImageView(int ImgNo, string HashTag)
        {
            ViewBag.HashTag = HashTag;

            // 이미지 조회
            DolPicPo po = _dao.GetPicView(ImgNo, DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME), HashTag);

            return Json(JsonConvert.SerializeObject(po));
        }

        /// <summary>
        /// 이미지 좋아요 Ajax
        /// </summary>
        /// <param name="Seq">고유번호</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PicLike(int Seq)
        {
            var UserId = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);
            DolPicPo po = new DolPicPo();

            // 로그인 체크
            if (string.IsNullOrEmpty(UserId))
            {
                po.RetCode = (int)e_RetCode.discord;
                po.RetMsg = "로그인후 사용 가능합니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 이미지 좋아요 처리
            po = _dao.PicLike(Seq, UserId);

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
            var UserId = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);
            DolPicPo po = new DolPicPo();

            // 로그인 체크
            if (string.IsNullOrEmpty(UserId))
            {
                po.RetCode = (int)e_RetCode.discord;
                po.RetMsg = "로그인후 사용 가능합니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 즐겨찾기 입력 처리
            po.RetCode = _dao.FavoriteInsert(TagNo, UserId);

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
            var UserId = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);
            DolPicPo po = new DolPicPo();

            // 로그인 체크
            if (string.IsNullOrEmpty(UserId))
            {
                po.RetCode = (int)e_RetCode.discord;
                po.RetMsg = "로그인후 사용 가능합니다.";

                return Json(JsonConvert.SerializeObject(po));
            }

            // 즐겨찾기 삭제 처리
            po.RetCode = _dao.FavoriteDelete(TagNo, UserId);

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

        #endregion

        #region 외부 API
        /// <summary>
        /// 이미지 저장
        /// </summary>
        /// <returns></returns>
        public void DolPicImageSave(int TagNo, string ImageSrc, int TagUrlType)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(ImageSrc);

            //log.ErrorFormat("TagNo == {0}", TagNo);
            //log.ErrorFormat("ImageSrc == {0}", System.Text.Encoding.UTF8.GetString(base64EncodedBytes));
            //log.ErrorFormat("TagUrlType == {0}", TagUrlType);

            DolPicVo entity = new DolPicVo();
            entity.Seq = TagNo;
            entity.ImageSrc = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            entity.TagUrlType = TagUrlType;

            AdminDao dao = new AdminDao();
            dao.DolPicImageInsert(entity);
        } 
        #endregion

        #region 바로가기 페이지 목록 만들기
        /// <summary>
        /// 바로가기 페이지 목록 만들기
        /// </summary>
        /// <param name="a_nCurPage">현재 페이지</param>
        /// <param name="a_nRecCnt">레코드 수</param>
        /// <param name="a_nPageSize">한페이지에 보여줄 페이지 수</param>
        /// <param name="a_nViewPageCnt">바로가기에 보여줄 페이지 수</param>
        /// <returns>바로가기목록</returns>
        private string GetGotoPageList(int a_nCurPage, int a_nRecCnt, int a_nPageSize, int a_nViewPageCnt)
        {
            StringBuilder sbPage = new StringBuilder();

            //바로가기 첫페이지 계산
            int nStartPage = ((a_nCurPage - 1) / a_nViewPageCnt) * a_nViewPageCnt + 1;
            // 전체 페이지수 계산
            int nPageCnt = (a_nRecCnt - 1) / a_nPageSize + 1;
            // 블럭페이지 계산
            int nBlockPage = ((a_nCurPage - 1) / a_nViewPageCnt) * a_nViewPageCnt + 1;

            if (nBlockPage != 1)
                sbPage.AppendFormat("<li page='{0}'><</li>&nbsp", nBlockPage - a_nViewPageCnt);

            int nCnt = 1;
            while (nStartPage <= nPageCnt && nCnt <= a_nViewPageCnt)
            {
                if (nStartPage == a_nCurPage)
                    sbPage.AppendFormat("<li page='{0}' class='on'>{0}</li>&nbsp;", nStartPage);
                else
                    sbPage.AppendFormat("<li page='{0}'>{0}</li>&nbsp;", nStartPage);

                nStartPage++;
                nCnt++;
                nBlockPage++;
            }

            if (nBlockPage < nPageCnt)
                sbPage.AppendFormat("<li page='{0}'>></li>", nBlockPage);

            return sbPage.ToString();
        } 
        #endregion
    }

    #region 이미지 리스트 결과값 클래스
    /// <summary>
    /// 이미지 리스트 결과값 클래스
    /// </summary>
    public class ReturnResult
    {
        public IList<DolPicVo> ImageList;
        public string PageGotoList;
    } 
    #endregion
}
