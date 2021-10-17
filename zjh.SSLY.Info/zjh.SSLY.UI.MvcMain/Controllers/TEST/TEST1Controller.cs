using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class TEST1Controller : Controller
    {
        //
        // GET: /TEST1/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }
    }
}
