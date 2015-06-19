using DolPic.Biz.DolPicUser;
using DolPic.Common;
using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class UserController : CustomController
    {
        private const string COOKIE_NAME = "user";
        // DAO
        private readonly IDolPicUser dao;

        /// <summary>
        /// 생성자
        /// </summary>
        public UserController()
        {
            //dao = new DolPicUser();
        }

        /// <summary>
        /// 로그인폼
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIn(UserPo model)
        {
            if (Request.UrlReferrer == null)
                model.ReferUrl = "/";
            else
                model.ReferUrl = Request.UrlReferrer.ToString();

            return View(model);
        }

        /// <summary>
        /// 로그아웃
        /// </summary>
        /// <returns></returns>
        public ActionResult LogOut()
        {
            Session.Clear();
            // 쿠키 삭제
            DolPicCookie.CookieDelete(this.HttpContext, COOKIE_NAME);

            return Redirect("/");
        }

        /// <summary>
        /// 회원가입
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SignUp(UserPo model)
        {
            if (ModelState.IsValid)
            {
                DolPicVo entity = new DolPicVo();
                entity.UserId = model.UserId;
                entity.UserPwd = model.UserPwd;

                DolPicDao dao = new DolPicDao();
                dao.DolPicUserSignUp(entity);

                model.RetCode = entity.RetCode;

                switch (entity.RetCode)
                {
                    case (int)e_RetCode.success:
                        if ("/User/SignUp".Equals(model.ReferUrl) || "/User/LogInProc".Equals(model.ReferUrl))
                            model.ReferUrl = "'/";
                        DolPicCookie.CookieWrite(this.HttpContext, COOKIE_NAME, model.UserId);
                        model.RetMsg = "회원 가입을 하셨습니다.";
                        break;

                    case (int)e_RetCode.has:
                        model.RetMsg = "이미 등록된 아이디 입니다.";
                        break;
                }

                return View(model);
            }

            return RedirectToAction("LogIn");
        }

        /// <summary>
        /// 로그인
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult LogInProc(UserPo model)
        {
            if (ModelState.IsValid)
            {
                DolPicVo entity = new DolPicVo();
                entity.UserId = model.UserId;
                entity.UserPwd = model.UserPwd;

                DolPicDao dao = new DolPicDao();
                dao.DolPicUserLogIn(entity);

                model.RetCode = entity.RetCode;

                switch (entity.RetCode)
                {
                    case (int)e_RetCode.success:
                        DolPicCookie.CookieWrite(this.HttpContext, COOKIE_NAME, model.UserId);

                        if ("/User/SignUp".Equals(model.ReferUrl) || "/User/LogInProc".Equals(model.ReferUrl))
                            model.ReferUrl = "'/";

                        model.RetMsg = "로그인 하셨습니다.";
                        break;

                    case (int)e_RetCode.no_has:
                        //model.ReferUrl = "/User/LogIn";
                        model.RetMsg = "등록된 아이디가 없습니다.";
                        break;

                    case (int)e_RetCode.not_auth:
                        //model.ReferUrl = "/User/LogIn";
                        model.RetMsg = "패스워드를 확인해주세요.";
                        break;
                }

                return View(model);
            }

            return RedirectToAction("LogIn");
        }
    }
}
