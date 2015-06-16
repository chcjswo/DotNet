using System;

namespace DolPic.Data.Pos
{
    public class DolPicPo
    {
        public string UserId { get; set; }
        public string UserPwd { get; set; }
        public string ImageSrc { get; set; }
        public int PrevSeq { get; set; }
        public int NextSeq { get; set; }
        public int RetCode { get; set; }
        public string RetMsg { get; set; }
    }
}
