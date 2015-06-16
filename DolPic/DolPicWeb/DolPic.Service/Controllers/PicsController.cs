using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class PicsController : CustomController
    {
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
        public ActionResult Main(string id)
        {
            DolPicVo entity = new DolPicVo();
            entity.HashTag = id ?? "";
            entity.TopCnt = 50;
            entity.CurPage = 1;

            DolPicDao dao = new DolPicDao();
            ViewBag.DataList = dao.MainImageList(entity);

            return View();
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
            po.PrevSeq = entity.PrevSeq;
            po.NextSeq = entity.NextSeq;

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

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIn()
        {
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
    }
}
