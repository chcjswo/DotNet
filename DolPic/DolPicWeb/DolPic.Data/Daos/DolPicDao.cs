using System.Collections.Generic;
using DolPic.Data.DataMappers.Service;
using DolPic.Data.Vos;

namespace DolPic.Data.Daos
{
    public class DolPicDao
    {
        /// <summary>
        /// 메인 이미지 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> MainImageList(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>("UP_MainImage_List", entity);
        }

        /// <summary>
        /// 이미지 조회
        /// </summary>
        /// <returns></returns>
        public void DolPicImageSelect(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>("UP_Image_Select", entity);
        }

        /// <summary>
        /// 초성 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> InitialList(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>("UP_Initial_List", entity);
        }

        /// <summary>
        /// 핫돌 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> HotDolPicList(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>("UP_HotDolPic_List", entity);
        }

        /// <summary>
        /// 회원 가입
        /// </summary>
        /// <returns></returns>
        public void DolPicUserSignUp(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>("UP_DolPicUser_Insert", entity);
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        public void DolPicUserLogIn(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>("UP_DolPicUser_Login", entity);
        }

        /// <summary>
        /// 이미지 좋아요
        /// </summary>
        /// <returns></returns>
        public void DolPicImageLikeInsert(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>("UP_DolPicImageLike_Insert", entity);
        }

        /// <summary>
        /// 즐겨찾기 입력
        /// </summary>
        /// <returns></returns>
        public void FavoriteInsert(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>("UP_Favorite_Insert", entity);
        }

        /// <summary>
        /// 즐겨찾기 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> FavoriteList(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>("UP_Favorite_List", entity);
        }

        /// <summary>
        /// 즐겨찾기 삭제
        /// </summary>
        /// <returns></returns>
        public void FavoriteDelete(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>("UP_Favorite_Delete", entity);
        }
    }
}
