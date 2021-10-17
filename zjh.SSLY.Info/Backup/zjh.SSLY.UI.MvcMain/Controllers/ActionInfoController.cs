using System;
using System.Collections.Generic;
using System.Data;
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
            return Json(data);
        }


        public ActionResult Save(ActionInfo action)
        {
            if (action.ID > 0)
            { 
                return Content("Ok");
            }

            var _rModel = bll.AddEntity(action);
            if (_rModel.ID > 0)
                return Content("Ok");
            return Content("Error");
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
