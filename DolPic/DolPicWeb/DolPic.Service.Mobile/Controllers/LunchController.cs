using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DolPic.Service.Mobile.Controllers
{
    public class LunchController : Controller
    {
        //
        // GET: /Lunch/

        public ActionResult Index()
        {
            return RedirectToAction("WhatEat");
        }

        public ActionResult WhatEat()
        {
            return View();
        }

        public ActionResult Pay()
        {
            return View();
        }

        public ActionResult Share()
        {
            return View();
        }

    }
}
