using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class UserController : CustomController
    {

        /// <summary>
        /// 로그인폼
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIn()
        {
            return View();
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        public ActionResult SignUp(DolPicPo model)
        {
            return Redirect("/");
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        public ActionResult LogInProc(DolPicPo model)
        {
            return Redirect("/");
        }
    }
}
