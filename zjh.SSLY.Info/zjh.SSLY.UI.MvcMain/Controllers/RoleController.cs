using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/

        private IRoleService roleService = new RoleService();
        private IUserInfoService userInfoService = new UserInfoService();
        //private IR_UserInfo_RoleService rUserInfoRoleService = new R_UserInfo_RoleService();
        //private IActionGroupService actionGroupService = new ActionGroupService();
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Edit(int id)
        {
            ViewData.Model = roleService.LoadEntities(r => r.ID == id).FirstOrDefault();
            return View();
        }


        public ActionResult SetActionGroupRole(int id)
        {
            //id:分组的id

            //ViewBag.GroupID = id;
            ////查询出要设置角色的组
            //var group = actionGroupService.LoadEntities(a => a.ID == id).FirstOrDefault();

            ////加载所有的角色
            //ViewData.Model = roleService.LoadEntities(u => true);
            //if (group != null)
            //{
            //    ViewBag.GroupRoleIds = group.Role.Select(r => r.ID).Distinct().AsEnumerable();
            //}
            return View();
        }

        /// <summary>
        /// 处理设置好的分组的角色
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SetActionGroupRole()
        {
            //第一步：清除现有分组的所有角色
            int groupId = int.Parse(Request["GroupID"] ?? "0");
            if (groupId > 0)
            {
                //var groupInfo = actionGroupService.LoadEntities(g => g.ID == groupId).FirstOrDefault();
                //if(groupInfo != null)
                //{
                //    groupInfo.Role.Clear();
                //}

                //第二步：将提交过来的新的分组的角色添加到中间表中
                var keys = from key in Request.Form.AllKeys
                           where key.Contains("ckb")
                           select key;

                List<int> roleIds = new List<int>();
                foreach (var key in keys)
                {
                    var idstr = int.Parse(key.Replace("ckb", ""));
                    //var role = roleService.LoadEntities(r => r.ID == idstr).FirstOrDefault();
                    //if(role != null)
                    //{
                    //    groupInfo.Role.Add(role);
                    //}
                    roleIds.Add(idstr);
                }
                //调用业务逻辑成处理分组角色
                //roleService.SetGroupInfoRole(roleIds, groupId);

            }

            return Content("Ok");
        }

        /// <summary>
        /// 设置用户角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetUserRole(int id)
        {
            //设置用户的主键
            //ViewBag.UserId = id;

            //var temp = roleService.LoadEntities(u => true);

            //var user = userInfoService.LoadEntities(u => u.ID == id).FirstOrDefault();
            //if (user != null)
            //{
            //    var roleIds = (from r_user_role in user.R_UserInfo_Role
            //                   select r_user_role.Role.ID).Distinct().AsEnumerable();

            //    ViewBag.RoleIds = roleIds;

            //}
            //return View(temp);
            return View();
        }

        public ActionResult UpdateUserRole()
        {
            //var userId = Request["UserId"];
            //var keys = from key in this.Request.Form.AllKeys
            //           where key.Contains("ckb")
            //           select key;
            ////清空原有的用户的角色
            //userInfoService.ClearUserRoles(int.Parse(userId));

            ////把提交回来的角色都放到数据库里面去
            //foreach (var key in keys)
            //{

            //    var temp = key.Replace("ckb", "");
            //    R_UserInfo_Role rUserInfoRole = new R_UserInfo_Role();
            //    rUserInfoRole.RoleID = int.Parse(temp);
            //    rUserInfoRole.UserInfoID = int.Parse(userId);
            //    rUserInfoRoleService.AddEntity(rUserInfoRole);
            //}
            return Content("Ok");
        }

        /// <summary>
        /// 修改 角色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(int id, Role role)
        {
            role.DelFlag = 0;//(int)CZBK.ShopJD.Model.Enum.DelFlagEnum.Normal;
            roleService.UpdateEntity(role);
            return Content("oK");
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <returns></returns>
        public ActionResult Delete()
        {
            string Ids = Request["ids"];
            if (!string.IsNullOrEmpty(Ids))
            {
                var strIds = Ids.Split(',');
                foreach (var strId in strIds)
                {
                    Role role = new Role();
                    role.ID = int.Parse(strId);
                    roleService.DeleteEntity(role);
                }
            }
            return Content("Ok");
        }


        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public ActionResult Create(Role role)
        {
            //魔鬼数字
            //role.DelFlag = 0;
            role.DelFlag = 0;// (int)CZBK.ShopJD.Model.Enum.DelFlagEnum.Normal;
            roleService.AddEntity(role);
            return Content("Ok");
        }

        public ActionResult LoadAllRole()
        {
            var pageSize = int.Parse(Request["rows"] ?? "10");
            var pageIndex = int.Parse(Request["page"] ?? "1");

            int totalCount = 0;

            var temp = roleService.LoadPageEntities(u => true, pageIndex, pageSize, out totalCount, r => r.ID, false);
            //Newtonsoft.Json
            return Content(JsonConvert.SerializeObject(new { total = totalCount, rows = temp }));
        }

    }
}
