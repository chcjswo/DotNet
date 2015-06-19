using DolPic.Data.Daos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using PagedList;
using DolPic.Common;
using Newtonsoft.Json;
using System.Xml;
using DolPic.Service.Web.Filters;
using DolPic.Biz.DolPicAdmin;

namespace DolPic.Service.Web.Controllers
{
    //[AdminAuth]
    public class DolPicAdminController : CustomController
    {
        private const string XML_FILE_NAME = "twitter_image.xml";
        // DAO
        private readonly IDolPicAdmin dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicAdminController()
        {
            dao = new DolPicAdmin();
        }

        public ActionResult Index()
        {
            return RedirectToAction("MenuList");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult MenuList()
        {
            return View();
        }

        #region 어드민 화면
        /// <summary>
        /// 해쉬태그 리스트 화면
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult HashTagList(int? page)
        {
            // 해쉬태그 리스트 조회
            var list = dao.GetHashTagList();

            ViewBag.DataCount = list.Count;
            ViewBag.DataList = list.ToPagedList(page ?? 1, 20);

            return View();
        }

        /// <summary>
        /// 해쉬태그 만들기 화면
        /// </summary>
        /// <returns></returns>
        public ActionResult HashTagMakeForm()
        {
            return View();
        }

        /// <summary>
        /// 이미지 리스트 화면
        /// </summary>
        /// <param name="Seq"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult DolPicImageList(int Seq, int? page)
        {
            var list = dao.GetDolPicImageList(Seq);

            ViewBag.DataCount = list.Count;
            ViewBag.DataList = list.ToPagedList(page ?? 1, 20);
            ViewBag.Seq = Seq;

            return View();
        } 
        #endregion

        [HttpPost]
        public ActionResult HashTagInsert(string HashTag, string Initial)
        {
            // 해쉬태그 입력
            var nRetCode = dao.HashTagInsert(HashTag, Initial);
            var result = new { RetCode = 99, RetMsg = "" };

            switch (nRetCode)
            {
                // 등록 성공
                case (int)e_RetCode.success:
                    result = new
                    {
                        RetCode = nRetCode,
                        RetMsg = "정상적으로 등록되었습니다."
                    };
                    break;

                // 이미 등록된 경우
                case (int)e_RetCode.has:
                    result = new
                    {
                        RetCode = nRetCode,
                        RetMsg = "이미 등록된 태그 입니다."
                    };
                    break;

                // DB에러
                case (int)e_RetCode.db_error:
                    result = new
                    {
                        RetCode = nRetCode,
                        RetMsg = "에러가 발생했습니다. 다시 한번 시도해주세요."
                    };
                    break;
            }

            return Json(JsonConvert.SerializeObject(result));
        }

        [HttpPost]
        public ActionResult HashTagXmlMake()
        {
            // 해쉬태그 리스트 조회
            var list = dao.GetHashTagList();
            var result = new { RetCode = 0, RetMsg = "" };

            try
            {
                MakeXml(list);
                result = new
                {
                    RetCode = 0,
                    RetMsg = "XML생성 완료"
                };
            }
            catch (Exception ex)
            {
                result = new
                {
                    RetCode = 1,
                    RetMsg = ex.ToString()
                };
            }

            return Json(JsonConvert.SerializeObject(result));
        }

        [HttpPost]
        public ActionResult HashTagDelete(int Seq)
        {
            // 해쉬태그 삭제 실행
            dao.HashTagDelete(Seq);

            return RedirectToAction("HashTagList");
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
