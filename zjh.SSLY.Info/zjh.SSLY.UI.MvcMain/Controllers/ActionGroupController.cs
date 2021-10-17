using Newtonsoft.Json;
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
    public class ActionGroupController : Controller
    {
        //
        // GET: /ActionGroup/
        private IActionGroupService bll = new ActionGroupService();
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
            List<ActionGroup> tmp = bll.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.Sort, false).ToList();
            var data = new { total = totalCount, rows = tmp }; 
            return Content(JsonConvert.SerializeObject(data));
        }
        public ActionResult Save(ActionGroup action)
        {
            if (action.ID > 0)
            {
                action.GroupName = Request["GroupName"];
                var _r = bll.UpdateEntity(action);
                if (_r)
                    return Content("Ok");
                return Content("Error");
            }
            else
            {
                action.GroupName = Request["GroupName"];
                action.GroupType = 0;
                action.SubTime = DateTime.Now;
                action.Sort = 0;
                var _rModel = bll.AddEntity(action);
                if (_rModel.ID > 0)
                    return Content("Ok");
                return Content("Error");
            }
        }
        #endregion


    }
}
