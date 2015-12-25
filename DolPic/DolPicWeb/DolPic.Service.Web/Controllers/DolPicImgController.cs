using DolPic.Biz.DolPicAdmin;
using DolPic.Data.Daos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using DolPic.Service.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace DolPic.Service.Web.Controllers
{
    /// <summary>
    /// 돌픽 크롤러에서 사용할 API 클래스
    /// </summary>
    public class DolPicImgController : CustomApiController
    {
        /// <summary>
        /// 돌픽 크롤러에서 이미지를 전송받아 저장하는 api
        /// POST api/dolpicimg
        /// </summary>
        /// <param name="item">저장할 이미지 정보</param>
        public void Post(HsahTag item)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(item.ImageSrc);

            DolPicVo entity = new DolPicVo();
            entity.Seq = item.TagNo;
            entity.ImageSrc = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            entity.TagUrlType = item.TagUrlType;

            AdminDao dao = new AdminDao();
            dao.DolPicImageInsert(entity);
        }

    }
}
