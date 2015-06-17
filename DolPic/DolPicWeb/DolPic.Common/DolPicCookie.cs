﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DolPic.Common
{
    /// <summary>
    /// 돌픽 쿠키 클래스
    /// </summary>
    public class DolPicCookie
    {
        private const string COOKIES_KEY = "dolpic_cookie";

        /// <summary>
        /// 쿠키 쓰기
        /// </summary>
        /// <param name="a_context"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void CookieWrite(HttpContextBase a_context, string key, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                CookieDelete(a_context, key);
                return;
            }

            HttpCookie cookie = a_context.Request.Cookies[COOKIES_KEY];
            if (cookie == null)
                cookie = new HttpCookie(COOKIES_KEY);

            cookie.Values[key] = (value);
            cookie.Path = "/";
            a_context.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 쿠키 삭제
        /// </summary>
        /// <param name="a_context"></param>
        /// <param name="key"></param>
        public static void CookieDelete(HttpContextBase a_context, string key)
        {
            HttpCookie cookie = a_context.Request.Cookies[COOKIES_KEY];
            cookie.Values[key] = null;
            cookie.Values.Remove(key);
            cookie.Expires = DateTime.Now.AddDays(1);
            cookie.Path = "/";
            a_context.Response.Cookies.Add(cookie);
        }

        /// <summary>
        /// 쿠키 읽기
        /// </summary>
        /// <param name="a_context"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string CookieRead(HttpContextBase a_context, string key)
        {
            HttpCookie cookie = a_context.Request.Cookies[COOKIES_KEY];
            if (cookie == null)
                return null;

            return (cookie[key]);
        }

        //private HttpContextBase _context;

        //public DolPicCookie(HttpContextBase context)
        //{
        //    _context = context;
        //}
    }
}
