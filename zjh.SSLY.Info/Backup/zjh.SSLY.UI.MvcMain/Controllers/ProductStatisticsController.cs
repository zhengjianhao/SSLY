using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class ProductStatisticsController : Controller
    {
        public string strDays = string.Empty;
        public string strData = "";

        //
        // GET: /ProductStatistics/ 
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult LoadTxPic(DateTime Date, string Account, string SKU)
        {
            int days = DateTime.DaysInMonth(Date.Year, Date.Month);
            ITbOrderHdrService bllhdr = new TbOrderHdrService();
            ITbOrderDtlService blldtl = new TbOrderDtlService();

            var lisHdr = bllhdr.LoadEntities(u => ((DateTime)u.PayTime).Year == Date.Year && ((DateTime)u.PayTime).Month == Date.Month);
            var lisdtl = blldtl.LoadEntities(u => lisHdr.Where(j => j.Formno == u.Formno).Count() > 0);

            var joinHdrDtls = lisdtl.Join(lisHdr, dtl => dtl.Formno, hdr => hdr.Formno, (dtl, hdr) => new { PayTime = ((DateTime)hdr.PayTime).Day });
            var rGby = joinHdrDtls.GroupBy(u => u.PayTime).Select(k => new Calendar { MouthDay = k.Key, SaleNum = k.Count() }).ToList();

            List<string> daysArrt = new List<string>();
            List<string> dataArrt = new List<string>();


            for (int i = 1; i < days + 1; i++)
            { 
                daysArrt.Add(Date.Year + "-" + Date.Month.ToString().PadLeft(2, '0') + "-" + i.ToString().PadLeft(2, '0'));
                var caleModels = rGby.Where(u => u.MouthDay == i).ToList(); 
                if (caleModels.Count > 0)
                { 
                    dataArrt.Add(caleModels[0].SaleNum.ToString());
                }
                else
                {
                    dataArrt.Add("0");
                } 
            } 
            var _Data = new { days = daysArrt, data = dataArrt };
            return Json(_Data, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult LoadMouthInfo(DateTime Date, string Account, string SKU)
        {
            int days = DateTime.DaysInMonth(Date.Year, Date.Month);
            ITbOrderHdrService bllhdr = new TbOrderHdrService();
            ITbOrderDtlService blldtl = new TbOrderDtlService();

            var lisHdr = bllhdr.LoadEntities(u => ((DateTime)u.PayTime).Year == Date.Year && ((DateTime)u.PayTime).Month == Date.Month);
            var lisdtl = blldtl.LoadEntities(u => lisHdr.Where(j => j.Formno == u.Formno).Count() > 0);

            var joinHdrDtls = lisdtl.Join(lisHdr, dtl => dtl.Formno, hdr => hdr.Formno, (dtl, hdr) => new { PayTime = ((DateTime)hdr.PayTime).Day });
            var rGby = joinHdrDtls.GroupBy(u => u.PayTime).Select(k => new Calendar { MouthDay = k.Key, SaleNum = k.Count() });
            var data = new { day = days, Gby = rGby };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }

    public class Calendar
    {
        /// <summary>
        /// 以月为单位第几天
        /// </summary>
        public int MouthDay { get; set; }

        /// <summary>
        /// 访客
        /// </summary>
        public int UV { get; set; }

        /// <summary>
        /// 成交量
        /// </summary>
        public int SaleNum { get; set; }
    }

}
