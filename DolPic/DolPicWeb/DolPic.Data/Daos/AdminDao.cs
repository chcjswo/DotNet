using System.Collections.Generic;
using DolPic.Data.DataMappers.Service;
using DolPic.Data.Vos;

namespace DolPic.Data.Daos
{
    public class AdminDao
    {
        /// <summary>
        /// 해쉬태그 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> HashTagList(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>(SqlMaps.Admin.UPA_HashTag_List, entity);
        }

        /// <summary>
        /// 인스타그램 해쉬태그 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> InstagramHashTagList(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>(SqlMaps.Admin.UPA_InstagramHashTag_List, entity);
        }

        /// <summary>
        /// 해쉬태그 입력
        /// </summary>
        /// <returns></returns>
        public void HashTagInsert(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_HashTag_Insert, entity);
        }

        /// <summary>
        /// 해쉬태그 수정
        /// </summary>
        /// <returns></returns>
        public void HashTagUpdate(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_HashTag_Update, entity);
        }

        /// <summary>
        /// 해쉬태그 삭제
        /// </summary>
        /// <returns></returns>
        public void HashTagDelete(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_HashTag_Delete, entity);
        }

        /// <summary>
        /// 해쉬태그 조회
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> HashTagSelect(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>(SqlMaps.Admin.UPA_HashTag_Select, entity);
        }

        /// <summary>
        /// 이미지 입력
        /// </summary>
        /// <returns></returns>
        public void DolPicImageInsert(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_DolPicImage_Insert, entity);
        }

        /// <summary>
        /// 이미지 삭제
        /// </summary>
        /// <returns></returns>
        public void DolPicImageDelete(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_DolPicImage_Delete, entity);
        }

        /// <summary>
        /// 이미지 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> DolPicImageList(DolPicVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>(SqlMaps.Admin.UPA_DolPicImage_List, entity);
        }

        /// <summary>
        /// 회원 리스트
        /// </summary>
        /// <returns></returns>
        public IList<UserVo> DolPicUserList(UserVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<UserVo>(SqlMaps.Admin.UPA_User_List, entity);
        }

        /// <summary>
        /// 회원 즐겨찾기 리스트
        /// </summary>
        /// <returns></returns>
        public IList<UserVo> DolPicUserFavoriteList(UserVo entity)
        {
            return DolPicServiceDataMapper.Instance().QueryForList<UserVo>(SqlMaps.Admin.UPA_UserFavorite_List, entity);
        }

        /// <summary>
        /// 모든 이미지 리스트
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> DolPicAllImageList()
        {
            return DolPicServiceDataMapper.Instance().QueryForList<DolPicVo>(SqlMaps.Admin.UPA_DolPicAllImage_List, null);
        }

        /// <summary>
        /// 짤린 이미지 삭제
        /// </summary>
        /// <returns></returns>
        public void DolPicNoImageDelete(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_DolPicNoImage_Delete, entity);
        }

    }
}
