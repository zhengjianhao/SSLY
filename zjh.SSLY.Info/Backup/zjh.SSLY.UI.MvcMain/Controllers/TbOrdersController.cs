using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Top.Api;
using Top.Api.Domain;
using Top.Api.Request;
using Top.Api.Response;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class TbOrdersController : Controller
    {
        IBLL.Info.ITbOrderHdrService bll = new BLL.Info.TbOrderHdrService();
        IBLL.Info.ITbOrderDtlService blldtl = new BLL.Info.TbOrderDtlService();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ImportOrder()
        {
            return View();
        }

        public ActionResult ImportOrderByCsv()
        {
            HttpPostedFileBase postedFile = Request.Files["filedata"];
            zjh.SSLY.Common.Info.TransferDataFactory tf = new Common.Info.TransferDataFactory();
            zjh.SSLY.Common.Info.ITransferData csv = tf.GetUtil(Common.Info.DataFileType.CSV);
            DataTable dt = csv.GetData(postedFile.InputStream);

            return View();
        }
        public ActionResult ManageMent()
        {
            TaoBaoRequest api = new TaoBaoRequest("hao坏坏");
            return Json(api.LogisticsAddressSearch(), JsonRequestBehavior.AllowGet);
        }

        #region crud

        //根据订单状态加载视图 
        public ActionResult LoadView()
        {
            var pageSize = int.Parse(Request["rows"] ?? "30");
            var pageIndex = int.Parse(Request["page"] ?? "1");
            int totalCount = 0;
            List<TbOrderHdr> tmp = bll.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.PayTime, false).ToList();

            var hdr = bll.LoadEntities(u => u.Status == "WAIT_SELLER_SEND_GOODS" || u.Status == "WAIT_BUYER_CONFIRM_GOODS");
            decimal totalPrice = blldtl.LoadEntities(u => hdr.Where(h => h.Formno == u.Formno).Count() > 0).Sum(u => u.Qty * u.Price);
            var data = new { price = totalPrice, total = totalCount, rows = tmp };
            return Json(data);
        }

        //根据订单状态加载视图 
        public ActionResult LoadDtl(string formno)
        {
            List<TbOrderDtl> tmp = blldtl.LoadEntities(u => u.Formno == formno).ToList();
            var data = new { total = tmp.Count, rows = tmp };
            return Json(data);
        }
        #endregion

        public ActionResult DownloadOrders(string Account)
        {
            ITbOrderHdrService bll = new TbOrderHdrService();
            ITbOrderDtlService blldtl = new TbOrderDtlService();
            TaoBaoRequest api = new TaoBaoRequest(Account);
            List<Top.Api.Domain.Trade> trades = api.LoadTradesOrders(DateTime.Parse("2015-04-01"), DateTime.Now).OrderBy(u => u.PayTime).ToList();
            foreach (Top.Api.Domain.Trade tr in trades)
            {
                string Tid = tr.Tid.ToString();
                var modelsList = bll.LoadEntities(u => u.OrderId == Tid).ToList();
                bool iscz = modelsList.Count > 0;
                TbOrderHdr hdr = new TbOrderHdr();
                if (iscz)
                {
                    hdr = modelsList[0];
                    hdr.Status = tr.Status;
                    bll.UpdateEntity(hdr);
                    continue;
                }
                if (tr.Payment != null)
                {
                    hdr.Payment = Decimal.Parse(tr.Payment);
                }
                if (tr.PayTime != null)
                {
                    hdr.PayTime = DateTime.Parse(tr.PayTime);
                }
                hdr.BuyerNick = tr.BuyerNick;
                hdr.OrderId = Tid;
                hdr.ReceiverAddress = tr.ReceiverAddress;
                hdr.ReceiverCity = tr.ReceiverCity;
                hdr.ReceiverDistrict = tr.ReceiverDistrict;
                hdr.ReceiverMobile = tr.ReceiverMobile;
                hdr.ReceiverPhone = tr.ReceiverPhone == null ? "" : tr.ReceiverPhone;
                hdr.ReceiverState = tr.ReceiverState;
                hdr.ReceiverZip = tr.ReceiverZip;
                hdr.Status = tr.Status;
                hdr.OrderStatus = 50;
                hdr.Account = Account;
                hdr.PicPath = tr.PicPath;
                hdr.ReceiverName = tr.ReceiverName;

                decimal CreditCardFee = 0;
                decimal.TryParse(tr.CreditCardFee, out CreditCardFee);
                hdr.CreditCardFee = CreditCardFee;

                hdr.AlipayAccount = "";
                hdr.Type = tr.Type;
                hdr.TradeFrom = tr.TradeFrom;

                List<TbOrderDtl> dtls = new List<TbOrderDtl>();

                foreach (Order o in tr.Orders)
                {
                    TbOrderDtl dtl = new TbOrderDtl()
                    {
                        Uid = 0,
                        CreateTime = DateTime.Now,
                        Qty = Convert.ToInt32(o.Num),
                        SKU = o.OuterIid,
                        Price = Convert.ToDecimal(o.Payment),
                        PicPath = o.PicPath
                    };
                    dtls.Add(dtl);
                }

                bool _r = bll.Save(hdr, dtls);
            }

            return Content("OK");
        }


        public ActionResult LogisticsOnlineSend(string tid, string TNum, string company_code)
        {
            #region MyRegion
            //tid	Number	必须	123456		淘宝交易ID
            //sub_tid	Number []	可选	1,2,3		拆单子订单列表，对应的数据是：子订单号的列表。可以不传，但是如果传了则必须符合传递的规则。子订单必须是操作的物流订单的子订单的真子集！
            //is_split	Number	可选	0	0	表明是否是拆单，默认值0，1表示拆单
            //out_sid	String	可选	123456789		运单号.具体一个物流公司的真实运单号码。淘宝官方物流会校验，请谨慎传入；
            //company_code	String	必须	POST		物流公司代码.如"POST"就代表中国邮政,"ZJS"就代表宅急送.调用 taobao.logistics.companies.get 获取。 
            //如果是货到付款订单，选择的物流公司必须支持货到付款发货方式
            //sender_id	Number	可选	123456		卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。如果为空，取的卖家的默认取货地址
            //cancel_id	Number	可选	123456		卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。
            //如果为空，取的卖家的默认退货地址
            //feature	String	可选	identCode=tid:aaa,bbb;machineCode=tid2:aaa		feature参数格式
            //范例: identCode=tid1:识别码1,识别码2|tid2:识别码3;machineCode=tid3:3C机器号A,3C机器号B
            //identCode为识别码的KEY,machineCode为3C的KEY,多个key之间用”;”分隔
            //“tid1:识别码1,识别码2|tid2:识别码3”为identCode对应的value。 "|"不同商品间的分隔符。
            //例1商品和2商品，之间就用"|"分开。
            //TID就是商品代表的子订单号，对应taobao.trade.fullinfo.get 接口获得的oid字段。(通过OID可以唯一定位到当前商品上)
            //":"TID和具体传入参数间的分隔符。冒号前表示TID,之后代表该商品的参数属性。
            //"," 属性间分隔符。（对应商品数量，当存在一个商品的数量超过1个时，用逗号分开）。
            //具体:当订单中A商品的数量为2个，其中手机串号分别为"12345","67890"。
            //参数格式：identCode=TIDA:12345,67890。 TIDA对应了A宝贝，冒号后用逗号分隔的"12345","67890".说明本订单A宝贝的数量为2，值分别为"12345","67890"。
            //当存在"|"时，就说明订单中存在多个商品，商品间用"|"分隔了开来。|"之后的内容含义同上。
            //seller_ip	String	可选	192.168.1.10		商家的IP地址 
            #endregion
            ITbOrderHdrService bll = new TbOrderHdrService();
            var model = bll.LoadEntities(u => u.OrderId == tid).ToList()[0];
            TaoBaoRequest api = new TaoBaoRequest(model.Account);
            LogisticsOnlineSendResponse response = api.LogisticsOnlineSend(long.Parse(tid), company_code, TNum);
            if (response.Body.Contains("<is_success>true</is_success>"))
            {
                return Content("成功");
            }
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return Json(response);
        }


        /// <summary>
        /// 同步物流公司
        /// </summary>
        /// <returns></returns>
        public ActionResult SynchLogisticsCompaniesGet()
        {
            TaoBaoRequest api = new TaoBaoRequest("hao坏坏");
            LogisticsCompaniesGetResponse rep = api.LogisticsCompaniesGet();
            return Json(rep, JsonRequestBehavior.AllowGet);
        }





        public ActionResult Print()
        {

            string sqlhdr = "SELECT 'http://localhost:1358/Content/images/TutorialPic.png' as TutorialPic,* FROM [dbo].[TbOrderHdr] WHERE ID IN (79)";
            string sqldtl = @"SELECT '两侧安装通用灯架English as a Second Language)线上学习体验' AS 'Titile','hei pi che kong mao xiang' SkuPropertiesName,'95.00' AS OriginalPrice,* FROM [dbo].[TbOrderDtl] WHERE Formno IN (
                             'TB150600081')";

            DataSet ds = new DataSet("订单");
            ds.Tables.Add(LoadBillOrder(sqlhdr, "主表"));
            ds.Tables.Add(LoadBillOrder(sqldtl, "明细"));

            using (StiReport report = new StiReport())
            {
                report.RegData(ds);
                string pathFild = AppDomain.CurrentDomain.BaseDirectory + "Report\\TbReport.mrt";
                report.Load(pathFild);
                report.Render(false);
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    report.ExportDocument(StiExportFormat.Pdf, ms);
                    return File(ms.ToArray(), "application/pdf");
                }
            }

        }
        public static DataTable LoadBillOrder(string sql, string TName)
        {
            DataTable dt = new DataTable(TName);
            using (SqlDataAdapter sda = new SqlDataAdapter(sql, "Data Source=10.0.0.57;Initial Catalog=BabySSLYInfo;User ID=admin;Password=123"))
            {
                sda.Fill(dt);
            }
            return dt;
        }


        public ActionResult PJ()
        {
            TaoBaoRequest api = new TaoBaoRequest("hao坏坏");
            //当 give seller 以卖家身份给买家的评价； 
            //当 get buyer  以卖家身份得到买家给的评价。


            long pageNo = 1;
            long pageSize = 100;
            var rep = api.TraderatesGet("get", "buyer", pageNo, pageSize, DateTime.Parse("2015-01-01"), DateTime.Now);

            bool load = true;
            while (load)
            {
                load = false;
                ITbTraderatesService bllttr = new TbTraderatesService();
                foreach (var rate in rep.TradeRates)
                {
                    TbTraderates ttr = new TbTraderates()
                    {
                        Content = rate.Content,
                        Created = DateTime.Parse(rate.Created),
                        ItemPrice = decimal.Parse(rate.ItemPrice),
                        ItemTitle = rate.ItemTitle,
                        Nick = rate.Nick,
                        NumIid = rate.NumIid.ToString(),
                        Oid = rate.Oid.ToString(),
                        OrderId = rate.Tid.ToString(),
                        RatedNick = rate.RatedNick,
                        Reply = rate.Reply,
                        Result = rate.Result,
                        ValidScore = rate.ValidScore,
                        Role = rate.Role
                    };
                    bllttr.AddEntity(ttr);
                } 
                if (rep.HasNext)
                {
                    pageNo++;
                    rep = api.TraderatesGet("give", "buyer", pageNo, pageSize, DateTime.Parse("2015-01-01"), DateTime.Now);
                    load = true;
                }
            } 
            return Content("OK");
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }


}
