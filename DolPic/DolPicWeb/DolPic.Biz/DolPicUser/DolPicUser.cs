using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;

namespace DolPic.Biz.DolPicUser
{
    public class DolPicUser : IDolPicUser
    {
        private readonly DolPicDao _dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicUser()
        {
            _dao = new DolPicDao();
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <param name="a_sUserPwd">유저 패스워드</param>
        /// <returns>결과값</returns>
        public int DolPicUserSignUp(string a_sUserId, string a_sUserPwd)
        {
            DolPicVo entity = new DolPicVo();
            entity.UserId = a_sUserId;
            entity.UserPwd = a_sUserPwd;

            _dao.DolPicUserSignUp(entity);

            return entity.RetCode;
        }

        /// <summary>
        /// 회원 로그인
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <param name="a_sUserPwd">유저 패스워드</param>
        /// <returns>결과값</returns>
        public UserPo DolPicUserLogIn(string a_sUserId, string a_sUserPwd)
        {
            DolPicVo entity = new DolPicVo();
            entity.UserId = a_sUserId;
            entity.UserPwd = a_sUserPwd;

            _dao.DolPicUserLogIn(entity);

            UserPo po = new UserPo();
            po.RetCode = entity.RetCode;
            po.UserRole = entity.UserRole;

            return po;
        }
    }
}
