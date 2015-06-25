using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Biz.DolPicService
{
    public class DolPicService : IDolPicService
    {
        private readonly DolPicDao _dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicService()
        {
            _dao = new DolPicDao();
        }

        /// <summary>
        /// 메인 이미지 리스트 조회
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public IList<DolPicVo> GetMainImageList(DolPicVo entity)
        {
            return _dao.MainImageList(entity);
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

            return _dao.InitialList(entity);
        }

        /// <summary>
        /// 핫 돌픽 리스트 조회
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> GetHotDolPicList()
        {
            DolPicVo entity = new DolPicVo();

            return _dao.HotDolPicList(entity);
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
            entity.SearchHashTag = a_sHahTag ?? "";

            _dao.DolPicImageSelect(entity);

            DolPicPo po = new DolPicPo();
            po.ImageSrc = entity.ImageSrc;
            po.HashTag = entity.HashTag;
            po.PrevSeq = entity.PrevSeq;
            po.NextSeq = entity.NextSeq;
            po.CurSeq = a_nSeq;
            po.IsLike = entity.IsLike;
            po.LikeCnt = entity.LikeCnt;

            return po;
        }

        /// <summary>
        /// 이미지 좋아요
        /// </summary>
        /// <param name="a_nSeq">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public DolPicPo PicLike(int a_nSeq, string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nSeq;
            entity.UserId = a_sUserId;

            _dao.DolPicImageLikeInsert(entity);

            DolPicPo po = new DolPicPo();
            po.RetCode = entity.RetCode;
            po.LikeCnt = entity.LikeCnt;

            return po;
        }

        /// <summary>
        /// 즐겨찾기 입력
        /// </summary>
        /// <param name="a_nTagNo">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public int FavoriteInsert(int a_nTagNo, string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nTagNo;
            entity.UserId = a_sUserId;

            _dao.FavoriteInsert(entity);

            return entity.RetCode;
        }

        /// <summary>
        /// 즐겨찾기 리스트 조회
        /// </summary>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public IList<DolPicVo> GetFavoriteList(string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.UserId = a_sUserId;

            return _dao.FavoriteList(entity);
        }

        /// <summary>
        /// 즐겨찾기 삭제
        /// </summary>
        /// <param name="a_nTagNo">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public int FavoriteDelete(int a_nTagNo, string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nTagNo;
            entity.UserId = a_sUserId;

            _dao.FavoriteDelete(entity);

            return entity.RetCode;
        }

        /// <summary>
        /// 신고하기 입력
        /// </summary>
        /// <param name="a_nImgNo">고유번호</param>
        /// <param name="a_sUserId">유저 아이디</param>
        /// <returns></returns>
        public int ImgReportInsert(int a_nImgNo, string a_sUserId)
        {
            DolPicVo entity = new DolPicVo();
            entity.Seq = a_nImgNo;
            entity.UserId = a_sUserId;

            _dao.DolPicImageReportInsert(entity);

            return entity.RetCode;
        }
    }
}
