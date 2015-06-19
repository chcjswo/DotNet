using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using System.Collections.Generic;

namespace DolPic.Biz.DolPicUser
{
    public class DolPicUser : IDolPicUser
    {
        private readonly DolPicUser dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public DolPicUser()
        {
            dao = new DolPicUser();
        }

    }
}
