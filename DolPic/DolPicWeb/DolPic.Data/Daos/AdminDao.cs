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
        /// 해쉬태그 입력
        /// </summary>
        /// <returns></returns>
        public void HashTagInsert(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_HashTag_Insert, entity);
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
        /// 이미지 입력
        /// </summary>
        /// <returns></returns>
        public void DolPicImageInsert(DolPicVo entity)
        {
            DolPicServiceDataMapper.Instance().QueryForObject<DolPicVo>(SqlMaps.Admin.UPA_DolPicImage_Insert, entity);
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
            return DolPicServiceDataMapper.Instance().QueryForList<UserVo>("UPA_User_List", entity);
        }

    }
}
