﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2()
        {
            return View();
        }
        public ActionResult AIAI()
        {
            return Content("OK");
        }
        public ActionResult test4()
        {
            return View();
        }
    }
}
