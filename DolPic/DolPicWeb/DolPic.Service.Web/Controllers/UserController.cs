using DolPic.Biz.DolPicUser;
using DolPic.Common;
using DolPic.Data.Pos;
using DolPic.Service.Web.Common;
using System.Web.Mvc;

namespace DolPic.Service.Web.Controllers
{
    public class UserController : CustomController
    {
        // DAO
        private readonly IDolPicUser _service;

        /// <summary>
        /// 생성자
        /// </summary>
        public UserController()
        {
            _service = new DolPicUser();
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
            DolPicCookie.CookieDelete(this.HttpContext, CommonVariable.COOKIE_NAME);

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
                // 회원가입 실행
                model.RetCode = _service.DolPicUserSignUp(model.UserId, model.UserPwd);

                switch (model.RetCode)
                {
                    case (int)e_RetCode.success:
                        if (CommonUtil.CheckReferrer(model.ReferUrl, string.Format("{0}/User/SignUp", Domains.WebDomain)) ||
                            CommonUtil.CheckReferrer(model.ReferUrl, string.Format("{0}/User/LogInProc", Domains.WebDomain)) ||
                            CommonUtil.CheckReferrer(model.ReferUrl, string.Format("{0}/User/LogIn", Domains.WebDomain)) ||
                            "".Equals(model.ReferUrl))
                            model.ReferUrl = Domains.WebDomain;

                        DolPicCookie.CookieWrite(this.Response, CommonVariable.COOKIE_NAME, model.UserId);
                        Session["UserRole"] = UserRole.normal;
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
                // 로그인 실행
                UserPo po = _service.DolPicUserLogIn(model.UserId, model.UserPwd);

                switch (po.RetCode)
                {
                    case (int)e_RetCode.success:
                        DolPicCookie.CookieWrite(this.Response, CommonVariable.COOKIE_NAME, model.UserId);

                        if (CommonUtil.CheckReferrer(model.ReferUrl, string.Format("{0}/User/SignUp", Domains.WebDomain)) ||
                            CommonUtil.CheckReferrer(model.ReferUrl, string.Format("{0}/User/LogInProc", Domains.WebDomain)) ||
                            CommonUtil.CheckReferrer(model.ReferUrl, string.Format("{0}/User/LogIn", Domains.WebDomain)) ||
                            "".Equals(model.ReferUrl))
                            po.ReferUrl = "/";
                        else
                            po.ReferUrl = model.ReferUrl;

                            Session["UserRole"] = po.UserRole;
                            Session.Timeout = 6000;

                        po.RetMsg = "로그인 하셨습니다.";
                        break;

                    case (int)e_RetCode.no_has:
                        po.RetMsg = "등록된 아이디가 없습니다.";
                        break;

                    case (int)e_RetCode.not_auth:
                        po.RetMsg = "패스워드를 확인해주세요.";
                        break;
                }

                return View(po);
            }

            return RedirectToAction("LogIn");
        }
    }
}
