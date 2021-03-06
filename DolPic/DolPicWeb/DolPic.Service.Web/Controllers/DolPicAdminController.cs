﻿using DolPic.Data.Vos;
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
    [AdminAuth(Roles = UserRole.admin)]
    public class DolPicAdminController : CustomController
    {
        private const string TW_XML_FILE_NAME = "twitter_image.xml";
        private const string INS_XML_FILE_NAME = "instagram_image.xml";

        private const string TW_TAG_NAME = "twitter";
        private const string INS_TAG_NAME = "instagram";
        // DAO
        private readonly IDolPicAdmin _service;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicAdminController()
        {
            _service = new DolPicAdmin();
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
            var list = _service.GetHashTagList();

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
        /// 해쉬태그 수정 화면
        /// </summary>
        /// <returns></returns>
        public ActionResult HashTagUpdateForm(int seq)
        {
            var list = _service.HashTagSelect(seq);
            DolPicVo vo = list[0];

            return View(vo);
        }

        /// <summary>
        /// 이미지 리스트 화면
        /// </summary>
        /// <param name="Seq"></param>
        /// <param name="page"></param>
        /// <returns></returns>
        public ActionResult DolPicImageList(int Seq, int? page)
        {
            var list = _service.GetDolPicImageList(Seq);

            ViewBag.DataCount = list.Count;
            ViewBag.DataList = list.ToPagedList(page ?? 1, 20);
            ViewBag.Seq = Seq;

            return View();
        }

        /// <summary>
        /// 회원 리스트 화면
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public ActionResult DolPicUserList(string UserId, int? page)
        {
            var list = _service.GetUserList(UserId ?? "");

            ViewBag.DataCount = list.Count;
            ViewBag.DataList = list.ToPagedList(page ?? 1, 20);
            ViewBag.UserId = UserId;
            ViewBag.CurPage = page ?? 1;

            return View();
        }

        /// <summary>
        /// 회원 즐겨찾기 리스트 화면
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public ActionResult DolPicUserFavoriteList(string UserId, int? page)
        {
            var list = _service.GetUserFavoriteList(UserId);

            ViewBag.DataCount = list.Count;
            ViewBag.DataList = list.ToPagedList(page ?? 1, 20);
            ViewBag.UserId = UserId;
            ViewBag.CurPage = page ?? 1;

            return View();
        }
        #endregion

        #region 어드민 동작
        [HttpPost]
        public ActionResult HashTagInsert(string HashTag, string Initial, string InstaHashTag)
        {
            // 해쉬태그 입력
            var nRetCode = _service.HashTagInsert(HashTag, Initial, InstaHashTag);
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
        public ActionResult HashTagUpdate(int Seq, string HashTag, string Initial, string InstaHashTag)
        {
            // 해쉬태그 입력
            var nRetCode = _service.HashTagUpdate(Seq, HashTag, Initial, InstaHashTag);
            var result = new { RetCode = 99, RetMsg = "" };

            switch (nRetCode)
            {
                // 등록 성공
                case (int)e_RetCode.success:
                    result = new
                    {
                        RetCode = nRetCode,
                        RetMsg = "정상적으로 수정 했습니다."
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
            var list = _service.GetHashTagList();
            // 인스타그램 리스트 조회
            var instaList = _service.GetInstagramHashTagList();

            var result = new { RetCode = 0, RetMsg = "" };

            try
            {
                // 해쉬태그 xml  만들기
                MakeXml(list, TW_TAG_NAME, TW_XML_FILE_NAME);

                // 인스타그램 해쉬태그 xml  만들기
                MakeXml(instaList, INS_TAG_NAME, INS_XML_FILE_NAME);

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
            _service.HashTagDelete(Seq);

            return RedirectToAction("HashTagList");
        }

        [HttpPost]
        public ActionResult DolPicImageDelete(int HashTagNo, int ImgNo)
        {
            // 이미지 삭제 실행
            _service.DolPicImageDelete(ImgNo);

            return RedirectToAction("DolPicImageList", new { Seq = HashTagNo});
        }
        #endregion

        #region 외부 API
        /// <summary>
        /// 이미지 저장
        /// </summary>
        /// <returns></returns>
        public void DolPicImageSave(int TagNo, string ImageSrc, int TagUrlType, int IsView)
        {
            log.DebugFormat("TagNo == {0}", TagNo);
            log.DebugFormat("ImageSrc == {0}", ImageSrc);
            log.DebugFormat("TagUrlType == {0}", TagUrlType);

            _service.DolPicImageInsert(TagNo, ImageSrc, TagUrlType);
        }
        #endregion

        #region XML문서 만들기
        /// <summary>
        /// 해쉬태그 XML문서 만들고 저장하기
        /// </summary>
        /// <param name="list">해쉬태그 리스트</param>
        private void MakeXml(IList<DolPicVo> list, string a_sTagName, string a_sFileName)
        {
            //DOM 문서 생성
            XmlDocument doc = new XmlDocument();
            //선언문
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "EUC-KR", "no");
            //주석
            XmlElement root = doc.CreateElement(a_sTagName);
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
                doc.Save(Server.MapPath("~/" + a_sFileName));
            }
        }
        #endregion

    }
}
