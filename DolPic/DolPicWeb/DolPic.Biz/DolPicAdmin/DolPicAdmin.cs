﻿using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Biz.DolPicAdmin
{
    public class DolPicAdmin : IDolPicAdmin
    {
        private readonly AdminDao dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicAdmin()
        {
            dao = new AdminDao();
        }

        /// <summary>
        /// 해쉬태그 리스트 조회
        /// </summary>
        /// <returns></returns>
        public IList<DolPicVo> GetHashTagList()
        {
            DolPicVo entity = new DolPicVo();
            AdminDao dao = new AdminDao();

            return dao.HashTagList(entity);
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

            AdminDao dao = new AdminDao();

            return  dao.DolPicImageList(entity);
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

            AdminDao dao = new AdminDao();
            dao.HashTagInsert(entity);

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

            AdminDao dao = new AdminDao();
            dao.HashTagDelete(entity);
        }
    }
}
