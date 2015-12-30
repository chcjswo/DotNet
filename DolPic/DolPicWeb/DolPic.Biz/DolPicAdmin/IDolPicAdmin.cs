using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Biz.DolPicAdmin
{
    public interface IDolPicAdmin
    {
        /// <summary>
        /// 해쉬태그 리스트 조회
        /// </summary>
        /// <returns></returns>
        IList<DolPicVo> GetHashTagList();

        /// <summary>
        /// 인스타그램 해쉬태그 리스트 조회
        /// </summary>
        /// <returns></returns>
        IList<DolPicVo> GetInstagramHashTagList();

        /// <summary>
        /// 이미지 리스트 조회
        /// </summary>
        /// <param name="a_nSeq">해쉬태그 고유번호</param>
        /// <returns></returns>
        IList<DolPicVo> GetDolPicImageList(int a_nHashTagNo);

        /// <summary>
        /// 이미지 입력
        /// </summary>
        /// <param name="a_nTagNo">해쉬태그 고유번호</param>
        /// <param name="a_sImageSrc">이미지 주소</param>
        /// <param name="a_nTagUrlType">이미지 출처</param>
        /// <returns></returns>
        void DolPicImageInsert(int a_nTagNo, string a_sImageSrc, int a_nTagUrlType);

        /// <summary>
        /// 이미지 삭제
        /// </summary>
        /// <param name="a_nImgNo">이미지 고유번호</param>
        /// <returns></returns>
        int DolPicImageDelete(int a_nImgNo);

        /// <summary>
        /// 해쉬태그 입력
        /// </summary>
        /// <param name="a_sHashTag">해쉬태그</param>
        /// <param name="a_sInitia">초성</param>
        /// <param name="a_sInstaHashTag">인스타그램 해쉬태그</param>
        /// <returns></returns>
        int HashTagInsert(string a_sHashTag, string a_sInitia, string a_sInstaHashTag);

        /// <summary>
        /// 해쉬태그 수정
        /// </summary>
        /// <param name="a_nHashTagNo">해쉬태그 고유번호</param>
        /// <param name="a_sHashTag">해쉬태그</param>
        /// <param name="a_sInitia">초성</param>
        /// <param name="a_sInstaHashTag">인스타그램 해쉬태그</param>
        /// <returns></returns>
        int HashTagUpdate(int a_nHashTagNo, string a_sHashTag, string a_sInitia, string a_sInstaHashTag);

        /// <summary>
        /// 해쉬태그 삭제
        /// </summary>
        /// <param name="a_nHashTagNo">해쉬태그 고유번호</param>
        /// <returns></returns>
        void HashTagDelete(int a_nHashTagNo);

        /// <summary>
        /// 해쉬태그 조회
        /// </summary>
        /// <param name="a_nHashTagNo">해쉬태그 고유번호</param>
        /// <returns></returns>
        IList<DolPicVo> HashTagSelect(int a_nHashTagNo);

        /// <summary>
        /// 회원 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        IList<UserVo> GetUserList(string a_sUserId);

        /// <summary>
        /// 회원 즐겨찾기 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        IList<UserVo> GetUserFavoriteList(string a_sUserId);

        /// <summary>
        /// 모든 이미지 리스트 조회
        /// </summary>
        /// <returns></returns>
        IList<DolPicVo> GetDolPicAllImageList();

        /// <summary>
        /// 짤린 이미지 삭제
        /// </summary>
        /// <param name="a_nSeq">이미지 고유번호</param>
        /// <returns></returns>
        void DolPicNoImageDelete(int a_nHashTagNo);
    }
}
