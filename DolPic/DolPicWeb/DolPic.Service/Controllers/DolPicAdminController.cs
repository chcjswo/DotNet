using DolPic.Data.Daos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DolPic.Common;
using Newtonsoft.Json;
using System.Xml;
using System.Web.Security;
using DolPic.Service.Web.Filters;

namespace DolPic.Service.Web.Controllers
{
    public class DolPicAdminController : CustomController
    {
        private const string XML_FILE_NAME = "twitter_image.xml";
        //
        // GET: /Admin/

        public ActionResult Index()
        {
            FormsAuthentication.SetAuthCookie("Admin", false);
            return RedirectToAction("MenuList");
        }

        [AdminAuth]
        public ActionResult MenuList()
        {
            return View();
        }

        public ActionResult HashTagList(int? page)
        {
            DolPicVo entity = new DolPicVo();

            AdminDao dao = new AdminDao();
            var list = dao.HashTagList(entity);

            ViewBag.DataCount = list.Count;
            ViewBag.DataList = list.ToPagedList(page ?? 1, 20);

            return View();
        }

        public ActionResult HashTagMakeForm()
        {
            return View();
        }

        [HttpPost]
        public ActionResult HashTagInsert(string HashTag, string Initial)
        {
            DolPicVo entity = new DolPicVo();
            entity.HashTag = HashTag;
            entity.Initial = Initial;

            AdminDao dao = new AdminDao();
            dao.HashTagInsert(entity);

            switch (entity.RetCode)
            {
                // 등록 성공
                case (int)e_RetCode.success:
                    entity.RetMsg = "정상적으로 등록되었습니다.";
                    break;

                // 이미 등록된 경우
                case (int)e_RetCode.has:
                    entity.RetMsg = "이미 등록된 태그 입니다.";
                    break;

                // DB에러
                case (int)e_RetCode.db_error:
                    entity.RetMsg = "에러가 발생했습니다. 다시 한번 시도해주세요.";
                    break;
            }

            return Json(JsonConvert.SerializeObject(entity));
        }

        [HttpPost]
        public ActionResult HashTagXmlMake()
        {
            DolPicVo entity = new DolPicVo();

            AdminDao dao = new AdminDao();
            var list = dao.HashTagList(entity);

            try
            {
                MakeXml(list);
                entity.RetMsg = "XML생성 완료";
            }
            catch (Exception ex)
            {
                entity.RetMsg = ex.ToString();
            }

            return Json(JsonConvert.SerializeObject(entity));
        }

        [HttpPost]
        public ActionResult HashTagDelete(int Seq)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = Seq;

            AdminDao dao = new AdminDao();
            dao.HashTagDelete(entity);

            return RedirectToAction("HashTagList");
        }

        public ActionResult DolPicImageList(int Seq, int? page)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = Seq;

            AdminDao dao = new AdminDao();
            var list = dao.DolPicImageList(entity);

            ViewBag.DataCount = list.Count;
            ViewBag.DataList = list.ToPagedList(page ?? 1, 20);
            ViewBag.Seq = Seq;

            return View();
        }

        private void MakeXml(IList<DolPicVo> list)
        {
            //DOM 문서 생성
            XmlDocument doc = new XmlDocument();
            //선언문
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "EUC-KR", "no");
            //주석
            XmlElement root = doc.CreateElement("twitter");
            //결합
            doc.AppendChild(dec);
            doc.AppendChild(root);

            foreach (var item in list)
            {
                XmlElement child = doc.CreateElement("images");

                root.AppendChild(child);

                //속성
                child.SetAttribute("no", item.Seq.ToString());
                child.SetAttribute("tag", item.HashTag);
            }

            // 뭔가 있으면 저장
            if (list.Count > 0)
            {
                // 지정된 XML문서로 만들고 저장한다.
                doc.Save(Server.MapPath("~/" + XML_FILE_NAME));
            }
        }

    }
}
