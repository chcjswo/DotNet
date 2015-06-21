using DolPic.Data.Pos;

namespace DolPic.Biz.DolPicUser
{
    public interface IDolPicUser
    {
        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <param name="a_sUserPwd">유저 패스워드</param>
        /// <returns>결과값</returns>
        int DolPicUserSignUp(string a_sUserId, string a_sUserPwd);

        /// <summary>
        /// 회원 로그인
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <param name="a_sUserPwd">유저 패스워드</param>
        /// <returns>결과값</returns>
        UserPo DolPicUserLogIn(string a_sUserId, string a_sUserPwd);
    }
}
