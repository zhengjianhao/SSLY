using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;
using zjh.SSLY.TaoBao;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class TbStoreController : Controller
    {

        //
        // GET: /TbStore/ 
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadView()
        {
            ITbStoreService bll = new TbStoreService();
            List<TbStore> tmp = bll.LoadEntities(u => u.ID > 0).ToList();
            var data = new { total = tmp.Count, rows = tmp };
            return Json(data);
        }

    }
}
