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
        //
        // GET: /Piscs/
        public ActionResult Index()
        {
            return RedirectToAction("Main");
        }

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

            DolPicDao dao = new DolPicDao();
            ViewBag.DataList = dao.MainImageList(entity);
            ViewBag.HashTag = id;
            ViewBag.PageGotoList = GetGotoPageList(1, entity.TotalCnt, 50, 10);

            return View();
        }

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

            DolPicDao dao = new DolPicDao();
            var list = dao.MainImageList(entity);

            ReturnResult result = new ReturnResult();
            result.ImageList = dao.MainImageList(entity);
            result.PageGotoList = GetGotoPageList(CurPage, entity.TotalCnt, 50, 10);

            return Json(JsonConvert.SerializeObject(result));
        }

        /// <summary>
        /// 이미지 보기
        /// </summary>
        /// <returns></returns>
        public ActionResult PicView(int id)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = id;

            DolPicDao dao = new DolPicDao();
            dao.DolPicImageSelect(entity);

            DolPicPo po = new DolPicPo();
            po.ImageSrc = entity.ImageSrc;
            po.HashTag = entity.HashTag;
            po.PrevSeq = entity.PrevSeq;
            po.NextSeq = entity.NextSeq;

            ViewBag.User = DolPicCookie.CookieRead(this.HttpContext, COOKIE_NAME);

            return View(po);
        }

        /// <summary>
        /// 이미지 보기
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ImageView(int Seq)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = Seq;

            DolPicDao dao = new DolPicDao();
            dao.DolPicImageSelect(entity);

            DolPicPo po = new DolPicPo();
            po.ImageSrc = entity.ImageSrc;
            po.HashTag = entity.HashTag;
            po.PrevSeq = entity.PrevSeq;
            po.NextSeq = entity.NextSeq;

            return Json(JsonConvert.SerializeObject(po));
        }

        /// <summary>
        /// 초성 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult InitialList()
        {
            DolPicVo entity = new DolPicVo();

            DolPicDao dao = new DolPicDao();
            ViewBag.DataList = dao.InitialList(entity);

            return View();
        }

        /// <summary>
        /// 핫돌픽 리스트
        /// </summary>
        /// <returns></returns>
        public ActionResult HotDolPicList()
        {
            DolPicVo entity = new DolPicVo();

            DolPicDao dao = new DolPicDao();
            ViewBag.DataList = dao.HotDolPicList(entity);

            return View();
        }

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

            log.DebugFormat("nPageCnt == {0}", nPageCnt);
            log.DebugFormat("nBlockPage == {0}", nBlockPage);

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
            //else
            //    sbPage.AppendFormat(" <img src='{0}' border=0' title='다음 페이지' align='absmiddle' onfocus='this.blur();' />", "asdfasd");

            //sbPage.Append(" <img src='/Images/btn_end.gif' style='cursor:pointer;' border=0' align='absmiddle' ");
            //sbPage.AppendFormat("onclick=\"{0}('{1}');\" ", a_sScriptName, nPageCnt);
            //sbPage.Append(" title='마지막 페이지' />");

            return sbPage.ToString();
        }
    }

    public class ReturnResult
    {
        public IList<DolPicVo> ImageList;
        public string PageGotoList;
    }
}
