using DolPic.Data.Daos;
using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Biz.DolPicAdmin
{
    public class DolPicAdmin : IDolPicAdmin
    {
        private readonly AdminDao _dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicAdmin()
        {
            _dao = new AdminDao();
        }

        /// <summary>
        /// 해쉬태그 리스트 조회
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> GetHashTagList()
        {
            DolPicVo entity = new DolPicVo();

            return _dao.HashTagList(entity);
        }

        /// <summary>
        /// 이미지 리스트 조회
        /// </summary>
        /// <param name="a_nSeq">해쉬태그 고유번호</param>
        /// <returns></returns>
        public IList<DolPicVo> GetDolPicImageList(int a_nHashTagNo)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nHashTagNo;

            return _dao.DolPicImageList(entity);
        }

        /// <summary>
        /// 이미지 입력
        /// </summary>
        /// <param name="a_nTagNo">해쉬태그 고유번호</param>
        /// <param name="a_sImageSrc">이미지 주소</param>
        /// <param name="a_nTagUrlType">이미지 출처</param>
        /// <returns></returns>
        public void DolPicImageInsert(int a_nTagNo, string a_sImageSrc, int a_nTagUrlType)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(a_sImageSrc);

            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nTagNo;
            entity.ImageSrc = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            entity.TagUrlType = a_nTagUrlType;

            _dao.DolPicImageInsert(entity);
        }

        /// <summary>
        /// 이미지 삭제
        /// </summary>
        /// <param name="a_nImgNo">이미지 고유번호</param>
        /// <returns></returns>
        public int DolPicImageDelete(int a_nImgNo)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nImgNo;

            _dao.DolPicImageDelete(entity);

            return entity.RetCode;
        }

        /// <summary>
        /// 해쉬태그 입력
        /// </summary>
        /// <param name="a_sHashTag">해쉬태그</param>
        /// <param name="a_sInitia">초성</param>
        /// <returns></returns>
        public int HashTagInsert(string a_sHashTag, string a_sInitia)
        {
            DolPicVo entity = new DolPicVo();
            entity.HashTag = a_sHashTag;
            entity.Initial = a_sInitia;

            _dao.HashTagInsert(entity);

            return entity.RetCode;
        }

        /// <summary>
        /// 해쉬태그 삭제
        /// </summary>
        /// <param name="a_nHashTagNo">해쉬태그 고유번호</param>
        /// <returns></returns>
        public void HashTagDelete(int a_nHashTagNo)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nHashTagNo;

            _dao.HashTagDelete(entity);
        }

        /// <summary>
        /// 회원 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public IList<UserVo> GetUserList(string a_sUserId)
        {
            UserVo entity = new UserVo();
            entity.UserId = a_sUserId;

            return _dao.DolPicUserList(entity);
        }

        /// <summary>
        /// 회원 즐겨찾기 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public IList<UserVo> GetUserFavoriteList(string a_sUserId)
        {
            UserVo entity = new UserVo();
            entity.UserId = a_sUserId;

            return _dao.DolPicUserFavoriteList(entity);
        }

        /// <summary>
        /// 모든 이미지 리스트 조회
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> GetDolPicAllImageList()
        {
            return _dao.DolPicAllImageList();
        }

        /// <summary>
        /// 짤린 이미지 삭제
        /// </summary>
        /// <param name="a_nImgNo">이미지 고유번호</param>
        /// <returns></returns>
        public void DolPicNoImageDelete(int a_nImgNo)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nImgNo;

            _dao.DolPicNoImageDelete(entity);
        }
    }
}
