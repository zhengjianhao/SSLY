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
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        zjh.SSLY.IBLL.Info.IUserInfoService bll = new BLL.Info.UserInfoService();
        //GET: /BillGoodsReceipt/

        public ActionResult Index()
        {
            return View();
        }


        #region crud
        public ActionResult Edit(UserInfo user)
        {
            return View();
        }
        public ActionResult Save(UserInfo user)
        {
            user.CreateTime = DateTime.Now;
            user.DelFlag = 0;
            user.LastLoginTime = DateTime.Now;
            user.LastModfiedDate = DateTime.Now;
            user.ErrorCount = 0;
            user.SubTime = DateTime.Now;

            var r = bll.AddEntity(user);
            if (r.ID > 0)
            {
                return Content("Ok");
            }
            return Content("Error");

        }

        //根据订单状态加载视图 
        public ActionResult LoadView()
        {
            var pageSize = int.Parse(Request["rows"] ?? "30");
            var pageIndex = int.Parse(Request["page"] ?? "1");
            int totalCount = 0;
            List<UserInfo> liUser = bll.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.CreateTime, false).ToList();

            var tmp = liUser.Select(u => new
                {
                    ID = u.ID,
                    UName = u.UName,
                    DelFlag = u.DelFlag,
                    UserPwd = u.UserPwd,
                    SubTime = u.SubTime,
                    LastModfiedDate = u.LastModfiedDate,
                    LastLoginTime = u.LastLoginTime,
                    ErrorCount = u.ErrorCount,
                    Email = u.Email,
                    Phone = u.Phone,
                    Remark = u.Remark,
                    Roles = ConverStringByRName(u.Role)
                });

            var data = new { total = totalCount, rows = tmp };
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            var str = jss.Serialize(data);
            return Content(str);
            //return Json(data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult SetRole(string uCode, string roles)
        {
            string[] arrRole = roles.Trim(',').Split(',');
            IRoleService bllRole = new RoleService();
            var liRoles = bllRole.LoadEntities(r => arrRole.Contains(r.RName)).ToList();

            var liUser = bll.LoadEntities(u => u.UCode.Equals(uCode)).ToList();
            if (liUser.Count > 0)
            {
                var user = liUser[0];
                foreach (var r in liRoles)
                {
                    bool _res = user.Role.Where(u => u.ID.Equals(r.ID)).Count() > 0;
                    if (!_res)
                    {
                        user.Role.Add(r);
                    }
                }
                bll.UpdateEntity(user);
            }
            return Content("Ok");
        }
        #endregion






        public string ConverStringByRName(System.Data.Objects.DataClasses.EntityCollection<Role> roles)
        {
            string strRoles = string.Empty;
            foreach (var item in roles)
            {
                strRoles += item.RName + ",";
            }
            return strRoles.Trim(',');
        }
    }
}
