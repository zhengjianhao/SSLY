using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult UserVerify(string userName, string pwd)
        {
            
            return View();
        }
    }
}
