using DolPic.Data.Pos;
using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Biz.DolPicService
{
    public interface IDolPicService
    {
        /// <summary>
        /// 메인 이미지 리스트 조회
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        IList<DolPicVo> GetMainImageList(DolPicVo entity);

        /// <summary>
        /// 초성 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        IList<DolPicVo> GetInitialList(string a_sUserId);

        /// <summary>
        /// 핫 돌픽 리스트 조회
        /// </summary>
        /// <returns></returns>
        IList<DolPicVo> GetHotDolPicList();

        /// <summary>
        /// 이미지 조회
        /// </summary>
        /// <param name="a_nSeq">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <param name="a_sHahTag">해쉬 태그</param>
        /// <returns></returns>
        DolPicPo GetPicView(int a_nSeq, string a_sUserId, string a_sHahTag);

        /// <summary>
        /// 이미지 좋아요
        /// </summary>
        /// <param name="a_nSeq">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        DolPicPo PicLike(int a_nSeq, string a_sUserId);

        /// <summary>
        /// 즐겨찾기 입력
        /// </summary>
        /// <param name="a_nTagNo">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        int FavoriteInsert(int a_nTagNo, string a_sUserId);

        /// <summary>
        /// 즐겨찾기 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        IList<DolPicVo> GetFavoriteList(string a_sUserId);

        /// <summary>
        /// 즐겨찾기 삭제
        /// </summary>
        /// <param name="a_nTagNo">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        int FavoriteDelete(int a_nTagNo, string a_sUserId);
    }
}
