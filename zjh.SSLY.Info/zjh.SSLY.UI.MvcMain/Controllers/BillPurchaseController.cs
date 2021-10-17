using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class BillPurchaseController : Controller
    {
        zjh.SSLY.IBLL.Info.IBillPurchaseHdrService bllHdr = new BLL.Info.BillPurchaseHdrService();
        zjh.SSLY.IBLL.Info.IBillPurchaseDtlService bllDtl = new BLL.Info.BillPurchaseDtlService();

        //GET: /BillPurchase/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(int id)
        {
            BillPurchaseHdr hdr = new BillPurchaseHdr();
            if (id == 0)
            {
                hdr.ID = 0;
            }
            else
            {
                List<BillPurchaseHdr> hdrs = bllHdr.LoadEntities(u => u.ID == id).ToList();
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
            var hdr = jss.Deserialize<BillPurchaseHdr>(jsonHdr);
            var rows = jss.Deserialize<BillPurchaseDtl[]>(jsonRows);

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
            List<BillPurchaseHdr> tmp = bllHdr.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.CreateTime, false).ToList();
            var data = new { total = totalCount, rows = tmp };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //根据订单状态加载视图 
        public ActionResult LoadDtl(string formno)
        {
            List<BillPurchaseDtl> tmp = bllDtl.LoadEntities(u => u.Formno == formno).ToList();
            var data = new { total = tmp.Count, rows = tmp };
            return Json(data);
        }


        public ActionResult InStock(string formnos)
        {
            string[] arr = formnos.Trim(',').Split(',');
            var liPurDtl = bllDtl.LoadEntities(u => arr.Contains(u.Formno)).ToList();
            var liPurHdr = bllHdr.LoadEntities(u => arr.Contains(u.Formno)).ToList();


            bool _cz = liPurDtl.Where(u => u.Leave == 0).Count() > 0;
            if (_cz)
            {
                return Content("已经是完成收货的订单，不需要再操作！");
            }

            zjh.SSLY.IBLL.Info.IBillGoodsReceiptHdrService bllGrDtl = new zjh.SSLY.BLL.Info.BillGoodsReceiptHdrService();
            foreach (var purHdr in liPurHdr)
            {
                List<BillGoodsReceiptDtl> grDtls = new List<BillGoodsReceiptDtl>();
                foreach (var purDtl in liPurDtl)
                {
                    purDtl.Leave = 0;
                    bool purResult = bllDtl.UpdateEntity(purDtl);
                    BillGoodsReceiptDtl gooddtl = new BillGoodsReceiptDtl()
                    {
                        Qty = purDtl.Qty,
                        ParentSn = purDtl.Sn,
                        WHID = "GZ",
                        Price = purDtl.Price,
                        Code = purDtl.Code,
                    };
                    if (purResult)
                    {
                        grDtls.Add(gooddtl);
                    }
                }

                BillGoodsReceiptHdr goodhdr = new BillGoodsReceiptHdr();
                goodhdr.Description = "";
                goodhdr.CreateTime = DateTime.Now;
                goodhdr.PFormno = purHdr.Formno;
                goodhdr.Active = true;
                goodhdr.CheckDate = DateTime.Now;
                goodhdr.Checker = 0;
                goodhdr.CheckState = "已审核";
                goodhdr.State = 0;
                goodhdr.WHID = "GZ";
                goodhdr.Deleted = false;
                bool _r = bllGrDtl.Save(goodhdr, grDtls);
            }

            return Content("OK");
        }
        #endregion

    }
}
