using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Biz
{
    public class DolPicService : IDolPicService
    {
        private readonly DolPicDao dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicService()
        {
            dao = new DolPicDao();
        }

        /// <summary>
        /// 메인 이미지 리스트 조회
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<DolPicVo> GetMainImageList(DolPicVo entity)
        {
            return dao.MainImageList(entity);
        }

        /// <summary>
        /// 초성 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public IList<DolPicVo> GetInitialList(string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.UserId = a_sUserId;

            return dao.InitialList(entity);
        }

        /// <summary>
        /// 핫 돌픽 리스트 조회
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> GetHotDolPicList()
        {
            DolPicVo entity = new DolPicVo();

            return dao.HotDolPicList(entity);
        }

        /// <summary>
        /// 이미지 조회
        /// </summary>
        /// <param name="a_nSeq">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <param name="a_sHahTag">해쉬 태그</param>
        /// <returns></returns>
        public DolPicPo GetPicView(int a_nSeq, string a_sUserId, string a_sHahTag)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nSeq;
            entity.UserId = a_sUserId;
            entity.HashTag = a_sHahTag ?? "";

            DolPicDao dao = new DolPicDao();
            dao.DolPicImageSelect(entity);

            DolPicPo po = new DolPicPo();
            po.ImageSrc = entity.ImageSrc;
            po.HashTag = entity.HashTag;
            po.PrevSeq = entity.PrevSeq;
            po.NextSeq = entity.NextSeq;
            po.CurSeq = a_nSeq;
            po.IsLike = entity.IsLike;

            return po;
        }

        /// <summary>
        /// 이미지 좋아요
        /// </summary>
        /// <param name="a_nSeq">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public int PicLike(int a_nSeq, string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nSeq;
            entity.UserId = a_sUserId;

            DolPicDao dao = new DolPicDao();
            dao.DolPicImageLikeInsert(entity);

            return entity.RetCode;
        }

        /// <summary>
        /// 이미지 저장 API
        /// </summary>
        /// <param name="a_nTagNo">태그 고유번호</param>
        /// <param name="a_sImageSrc">이미지 주소</param>
        /// <param name="a_nTagUrlType">태그 타입</param>
        /// <returns></returns>
        public void PicLike(int a_nTagNo, string a_sImageSrc, int a_nTagUrlType)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(a_sImageSrc);

            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nTagNo;
            entity.ImageSrc = System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            entity.TagUrlType = a_nTagUrlType;

            AdminDao dao = new AdminDao();
            dao.DolPicImageInsert(entity);
        }

        /// <summary>
        /// 해쉬태그 즐겨찾기 입력
        /// </summary>
        /// <param name="a_nTagNo">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public int HashTagFavoriteInsert(int a_nTagNo, string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nTagNo;
            entity.UserId = a_sUserId;

            DolPicDao dao = new DolPicDao();
            dao.HashTagFavoriteInsert(entity);

            return entity.RetCode;
        }
    }
}
