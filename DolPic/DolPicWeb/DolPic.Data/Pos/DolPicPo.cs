using System;

namespace DolPic.Data.Pos
{
    public class DolPicPo
    {
        public string ImageSrc { get; set; }
        public string HashTag { get; set; }
        public int CurSeq { get; set; }
        public int PrevSeq { get; set; }
        public int NextSeq { get; set; }
        public int RetCode { get; set; }
        public string RetMsg { get; set; }
        public short IsLike { get; set; }
        public int LikeCnt { get; set; }
    }
}
