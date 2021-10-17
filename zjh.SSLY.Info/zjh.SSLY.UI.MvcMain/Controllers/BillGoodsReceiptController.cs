using System;
using System.Collections.Generic;
using System.Web.Mvc;
using zjh.SSLY.Model.Info;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class BillGoodsReceiptController : Controller
    {
        zjh.SSLY.IBLL.Info.IBillGoodsReceiptHdrService bllHdr = new BLL.Info.BillGoodsReceiptHdrService();
        zjh.SSLY.IBLL.Info.IBillGoodsReceiptDtlService bllDtl = new BLL.Info.BillGoodsReceiptDtlService();

        //GET: /BillGoodsReceipt/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            BillGoodsReceiptHdr hdr = new BillGoodsReceiptHdr();
            if (id == 0)
            {
                hdr.ID = 0;
            }
            else
            {
                List<BillGoodsReceiptHdr> hdrs = bllHdr.LoadEntities(u => u.ID == id).ToList();
                hdr = hdrs[0];
            }
            ViewBag.Model = hdr;
            return View();
        }

        #region crud

        public ActionResult Save(string jsonHdr, string jsonRows)
        {
            //LoadData(ref hdr, ref dtls);
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            var hdr = jss.Deserialize<BillGoodsReceiptHdr>(jsonHdr);
            var rows = jss.Deserialize<BillGoodsReceiptDtl[]>(jsonRows);

            if (hdr.ID > 0)
            {
                var hdrs = bllHdr.LoadEntities(u => u.Formno == hdr.Formno).ToList();
                if (hdrs.Count > 0)
                {
                    hdrs[0].Description = hdr.Description;
                    bool result = bllHdr.UpdateEntity(hdrs[0]);
                    if (result)
                    {
                        return Content("Ok");
                    }
                }
            }
            else
            {
                hdr.Description = hdr.Description;
                hdr.CreateTime = DateTime.Now;
                hdr.PFormno = "/";
                hdr.Active = true;
                hdr.CheckDate = DateTime.Now;
                hdr.Checker = 0;
                hdr.CheckState = "已审核";
                hdr.State = 0;
                hdr.Deleted = false;
                bool _r = bllHdr.Save(hdr, rows.ToList());
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
            List<BillGoodsReceiptHdr> tmp = bllHdr.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.CreateTime, false).ToList();
            var data = new { total = totalCount, rows = tmp };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //根据订单状态加载视图 
        public ActionResult LoadDtl(string formno)
        {
            List<BillGoodsReceiptDtl> tmp = bllDtl.LoadEntities(u => u.Formno == formno).ToList();
            var data = new { total = tmp.Count, rows = tmp };
            return Json(data);
        }

        #endregion

    }
}
