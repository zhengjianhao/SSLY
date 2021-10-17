using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class BaseController : Controller
    {
        private bool _IsCheck = true;

        private UserInfo _CurrentUserInfo;

        public UserInfo CurrentUserInfo
        {
            get
            {
                if (_CurrentUserInfo == null)
                {
                    _CurrentUserInfo = (UserInfo)Session["UserInfo"];
                }
                return _CurrentUserInfo;
            }
            set { _CurrentUserInfo = value; }
        }

        public bool IsCheck
        {
            get { return _IsCheck; }
            set { _IsCheck = value; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            //校验用户是否已经登录
            var userInfo = this.Session["UserInfo"];
            if (userInfo == null)
            {
                //跳转到登录页面
                this.Response.Redirect("/Login/LogOn");
                return;
            }

            if (((UserInfo)userInfo).Role.Where(u => u.RName == "Administrator").Count() > 0)
            {
                return;
            }

            if (!IsCheck)
            {
                return;
            }

            //校验请求是否具有权限 

            //获取当前请求对应的url地址
            var strUrl = filterContext.HttpContext.Request.Url.AbsolutePath;
            //HttpTypeEnum httpTypeEnum = HttpTypeEnum.Post;

            ////Get,Post确定是那种请求
            //if (filterContext.HttpContext.Request.HttpMethod == "GET")
            //{
            //    httpTypeEnum = HttpTypeEnum.Get;
            //}

            ////获取当前请求是对应哪个权限
            IActionInfoService actionInfoService = new ActionInfoService();

            //short httpType = (short)httpTypeEnum;
            var actionInfo = actionInfoService.LoadEntities(a => a.ActionCode == strUrl).FirstOrDefault();
            var rUserInfoRole = actionInfoService.IsActionInfoIsOk(actionInfo, CurrentUserInfo);
            if (rUserInfoRole)
            {
                return;
            }
            else
            {
                this.Response.Redirect("/Error.htm");
            }
        }
          
        //protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        //{
        //    return new JsonNetResult
        //    {
        //        Data = data,
        //        ContentType = contentType,
        //        ContentEncoding = contentEncoding,
        //        JsonRequestBehavior = behavior
        //    };
        //}
    }
}
