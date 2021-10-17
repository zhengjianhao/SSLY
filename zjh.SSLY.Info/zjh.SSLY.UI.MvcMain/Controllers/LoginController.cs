using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        IUserInfoService userInfoService = new UserInfoService();

        [HttpGet]
        public ActionResult LogOn()
        {
            Session["UserInfo"] = null;
            return View();

        }



        [HttpPost]
        public ActionResult LogOn(FormCollection collection)
        {
            var strName = Request["LoginCode"];
            var pwd = Request["LoginPwd"]; 
            object data = null;

            //校验逻辑 
            var userInfo = userInfoService.Login(new LoginUserInfo() { UCode = strName, Pwd = pwd });
            if (userInfo == null)
            {
                data = new { IsSuccess = false, Content = "帐号或者密码不正确!" };
               
            }
            else
            {
                Session["UserInfo"] = userInfo;
                data = new { IsSuccess = true, Content = "/Home" }; 
            }
            return Json(data);

        }



        public ActionResult LogOff()
        {
            Session["UserInfo"] = null;
            return RedirectToAction("LogOn", "Login");
        }

    }
}
