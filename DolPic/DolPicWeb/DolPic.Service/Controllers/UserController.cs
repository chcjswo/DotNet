using DolPic.Common;
using DolPic.Data.Daos;
using DolPic.Data.Pos;
using DolPic.Data.Vos;
using DolPic.Service.Web.Common;
using Newtonsoft.Json;
using System.Web;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class UserController : CustomController
    {

        /// <summary>
        /// 로그인폼
        /// </summary>
        /// <returns></returns>
        public ActionResult LogIn(UserPo model)
        {
            model.ReferUrl = Request.UrlReferrer.ToString();

            return View(model);
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

                        var userCookie = new HttpCookie("user", model.UserId);
                        HttpContext.Response.SetCookie(userCookie);
                        HttpContext.Response.Cookies.Add(userCookie);

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
