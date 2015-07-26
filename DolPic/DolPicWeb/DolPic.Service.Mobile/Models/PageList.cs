using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Service.Mobile.Models
{
    /// <summary>
    /// 이미지 리스트 결과값 클래스
    /// </summary>
    public class PageList
    {
        public IList<DolPicVo> ImageList;
        public string PageGotoList;
    } 
}