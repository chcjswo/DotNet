using System;

namespace DolPic.Data.Vos
{
    public class UserVo
    {
        /// <summary>
        /// 회원 아이디
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 회원 비번
        /// </summary>
        public string UserPwd { get; set; }

        /// <summary>
        /// 즐겨찾기 고유번호
        /// </summary>
        public short UserRole { get; set; }

        /// <summary>
        /// 등록일
        /// </summary>
        public DateTime RegDate { get; set; }

        /// <summary>
        /// 로그인 날짜
        /// </summary>
        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// 패스워드 변경 날자
        /// </summary>
        public DateTime PwUpdateDate { get; set; }

        /// <summary>
        /// 해쉬태그
        /// </summary>
        public DateTime HashTag { get; set; }

        public short RetCode { get; set; }
        public string RetMsg { get; set; }

    }
}
