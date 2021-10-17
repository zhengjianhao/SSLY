
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects.DataClasses;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class ActionInfoController : Controller
    {
        IBLL.Info.IActionInfoService bll = new BLL.Info.ActionInfoService();
        public ActionResult Index()
        {
            return View();
        }

        #region crud

        //根据订单状态加载视图 
        public ActionResult LoadView()
        {
            var pageSize = int.Parse(Request["rows"] ?? "30");
            var pageIndex = int.Parse(Request["page"] ?? "1");
            int totalCount = 0;
            List<ActionInfo> tmp = bll.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.Sort, false).ToList();
            var data = new { total = totalCount, rows = tmp }; 
            return Content(JsonConvert.SerializeObject(data));
        }


        public ActionResult Save()
        {
            int actionGroup_ID = int.Parse(Request["ActionGroup_ID"]);
            IActionGroupService aGroup = new ActionGroupService();
            var gpModel = aGroup.LoadEntities(u => u.ID == actionGroup_ID).FirstOrDefault();
            if (gpModel == null)
                return Content("Error");


            ActionInfo action = new ActionInfo();
            action.ActionCode = Request["ActionCode"];
            action.ActionName = Request["ActionName"];
            action.Remark = Request["Remark"];
            action.HttpType = short.Parse(Request["HttpType"]);
            action.DelFlag = 0;
            action.SubTime = DateTime.Now;
            action.Sort = 1;
            action.ActionGroup = gpModel;
            var _rModel = bll.AddEntity(action);
            if (_rModel.ID > 0)
                return Content("Ok");
            return Content("Error");
        }




        public ActionResult ShowRoleAction()
        {
            return View();
        }



        /// <summary>
        /// 设置角色权限
        /// </summary>
        /// <param name="aid"></param>
        /// <param name="roleID"></param>
        /// <returns></returns>
        public ActionResult SetRoleAction(string aid, int roleID)
        {
            string[] aids = aid.Split(',');
            List<int> ids = new List<int>();
            foreach (var a in aids)
            {
                ids.Add(int.Parse(a));
            }





            bool _isClear = bll.ClearRoleAcion(roleID);
            if (!_isClear)
                return Content("Error");
            var temp = bll.LoadEntities(a => ids.Contains(a.ID)).ToList();

            IRoleService roleService = new RoleService();
            var role = roleService.LoadEntities(r => r.ID == roleID).FirstOrDefault();
            foreach (var action in temp)
            {
                role.ActionInfo.Add(action);
            }

            bool _r = roleService.UpdateEntity(role);
            if (_r)
            {
                return Content("Ok");
            }
            return Content("Error");
        }



        public ActionResult LoadTree(int roleID)
        {
            IActionGroupService actionGroup = new ActionGroupService();
            List<ActionGroup> temp = actionGroup.LoadEntities(u => u.ID > 0).ToList();




            IRoleService roleService = new RoleService();
            Role role = roleService.LoadEntities(r => r.ID == roleID).FirstOrDefault();
            List<ActionInfo> liAction = new List<ActionInfo>();
            if (role != null)
            {
                liAction = role.ActionInfo.ToList();
            }


            List<ActionInfoTree> tempTrees = new List<ActionInfoTree>();
            ActionInfoTree tree = new ActionInfoTree();
            tree.children = new List<ActionInfoTree>();
            tree.text = "全部";
            foreach (var gr in temp)
            {
                ActionInfoTree fist = new ActionInfoTree();
                fist.ActionName = gr.GroupName;
                fist.text = gr.GroupName;
                fist.children = new List<ActionInfoTree>();
                foreach (var action in gr.ActionInfo)
                {
                    ActionInfoTree chr = new ActionInfoTree();
                    chr.text = action.ActionName;
                    chr.ID = action.ID;
                    chr.ActionCode = action.ActionCode;
                    chr.checkeds = liAction.Where(l => l.ID == action.ID).Count() > 0;
                    fist.children.Add(chr);
                }
                tree.children.Add(fist);
            }
            tempTrees.Add(tree);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

            return Content(jss.Serialize(tempTrees).Replace("checkeds", "checked"));
        }


        #endregion


        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
