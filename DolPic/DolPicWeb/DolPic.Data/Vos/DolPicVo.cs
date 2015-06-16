using System;

namespace DolPic.Data.Vos
{
    public class DolPicVo
    {
        /// <summary>
        /// 고유번호
        /// </summary>
        public int Seq { get; set; }

        /// <summary>
        /// 고유번호
        /// </summary>
        public int HashTagSeq { get; set; }

        /// <summary>
        /// 해쉬태그
        /// </summary>
        public string HashTag { get; set; }

        /// <summary>
        /// 초성
        /// </summary>
        public string Initial { get; set; }

        /// <summary>
        /// 이미지 경로
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 좋아요 수
        /// </summary>
        public int LikeCnt { get; set; }

        /// <summary>
        /// 초성 수
        /// </summary>
        public int InitialCnt { get; set; }

        /// <summary>
        /// 저장 URL 타입
        /// </summary>
        public int TagUrlType { get; set; }

        /// <summary>
        /// 회원 아이디
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 회원 비번
        /// </summary>
        public string UserPwd { get; set; }

        public int PrevSeq { get; set; }
        public int NextSeq { get; set; }
        public int TotalCnt { get; set; }
        public int CurPage { get; set; }
        public int RetCode { get; set; }
        public string RetMsg { get; set; }

    }
}
