using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;

namespace zjh.SSLY.UI.MvcMain
{
    public class TaoBaoRequest
    {
        public string appkey = "23143997";
        public string appsecret = "1f28b7e98d0dd6930765119a8c63a617";
        public string gateway = @"http://gw.api.taobao.com/router/rest";
        public string sessionKey = string.Empty;

        public TaoBaoRequest(int TbStoreID)
        {
            BLL.Info.TbStoreService bll = new BLL.Info.TbStoreService();
            var model = bll.LoadEntities(u => u.ID == TbStoreID).ToList()[0];
            this.sessionKey = model.SessionKey;
        }

        public TaoBaoRequest(string Account)
        {
            BLL.Info.TbStoreService bll = new BLL.Info.TbStoreService();
            var model = bll.LoadEntities(u => u.Account == Account).ToList()[0];
            this.sessionKey = model.SessionKey;
        }


        /// <summary>
        /// 订单加载  taobao.trades.sold.get
        /// </summary>
        /// <param name="StartCreated">开始时间</param>
        /// <param name="EndCreated">结束时间</param>
        /// <returns></returns>
        public List<Top.Api.Domain.Trade> LoadTradesOrders(DateTime StartCreated, DateTime EndCreated)
        {
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            TradesSoldGetRequest req = new TradesSoldGetRequest();
            req.Fields = "seller_nick,buyer_nick,title,type,created,sid,tid,seller_rate,buyer_rate,status,payment,discount_fee,adjust_fee,post_fee,total_fee,pay_time,end_time,modified,consign_time,buyer_obtain_point_fee,point_fee,real_point_fee,received_payment,commission_fee,pic_path,num_iid,num_iid,num,price,cod_fee,cod_status,shipping_type,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,orders.title,orders.pic_path,orders.price,orders.num,orders.iid,orders.num_iid,orders.sku_id,orders.refund_status,orders.status,orders.oid,orders.total_fee,orders.payment,orders.discount_fee,orders.adjust_fee,orders.sku_properties_name,orders.item_meal_name,orders.buyer_rate,orders.seller_rate,orders.outer_iid,orders.outer_sku_id,orders.refund_id,orders.seller_type";
            req.UseHasNext = true;
            req.PageSize = 100;
            req.StartCreated = StartCreated;
            req.EndCreated = EndCreated;
            TradesSoldGetResponse response = client.Execute(req, sessionKey);
            return response.Trades;
        }

        /// <summary>
        ///  LogisticsOnlineSendResponse
        /// </summary>
        /// <param name="StartCreated">开始时间</param>
        /// <param name="EndCreated">结束时间</param>
        /// <returns></returns>
        public LogisticsOnlineSendResponse LogisticsOnlineSend(long tid, string company_code, string OutSid)
        {
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            LogisticsOnlineSendRequest req = new LogisticsOnlineSendRequest();
            req.Tid = tid;
            req.CompanyCode = company_code;
            req.OutSid = OutSid;
            return client.Execute(req, sessionKey);
        }

        /// <summary>
        ///  LogisticsOnlineSendResponse
        /// </summary>
        /// <param name="StartCreated">开始时间</param>
        /// <param name="EndCreated">结束时间</param>
        /// <returns></returns>
        public LogisticsCompaniesGetResponse LogisticsCompaniesGet()
        {
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            LogisticsCompaniesGetRequest req = new LogisticsCompaniesGetRequest();
            req.Fields = "id,code,name,reg_mail_no";
            return client.Execute(req, sessionKey);
        }

        /// <summary>
        ///  LogisticsOnlineSendResponse
        /// </summary>
        /// <param name="StartCreated">开始时间</param>
        /// <param name="EndCreated">结束时间</param>
        /// <returns></returns>
        public TradeGetResponse TradeGet(string tid)
        {
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            TradeGetRequest rep = new TradeGetRequest();
            rep.Fields = "seller_nick,buyer_nick,title,type,created,sid,tid,seller_rate,buyer_rate,status,payment,discount_fee,adjust_fee,post_fee,total_fee,pay_time,end_time,modified,consign_time,buyer_obtain_point_fee,point_fee,real_point_fee,received_payment,commission_fee,pic_path,num_iid,num_iid,num,price,cod_fee,cod_status,shipping_type,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,orders.title,orders.pic_path,orders.price,orders.num,orders.iid,orders.num_iid,orders.sku_id,orders.refund_status,orders.status,orders.oid,orders.total_fee,orders.payment,orders.discount_fee,orders.adjust_fee,orders.sku_properties_name,orders.item_meal_name,orders.buyer_rate,orders.seller_rate,orders.outer_iid,orders.outer_sku_id,orders.refund_id,orders.seller_type";

            rep.Tid = long.Parse(tid);
            return client.Execute(rep, sessionKey);
        }

        /// <summary>
        ///  LogisticsOnlineSendResponse
        /// </summary>
        /// <param name="StartCreated">开始时间</param>
        /// <param name="EndCreated">结束时间</param>
        /// <returns></returns>
        public TradeFullinfoGetResponse TradeFullinfoGet(string tid)
        {
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            TradeFullinfoGetRequest rep = new TradeFullinfoGetRequest();
            rep.Fields = "seller_nick,buyer_nick,title,type,created,sid,tid,seller_rate,buyer_rate,status,payment,discount_fee,adjust_fee,post_fee,total_fee,pay_time,end_time,modified,consign_time,buyer_obtain_point_fee,point_fee,real_point_fee,received_payment,commission_fee,pic_path,num_iid,num_iid,num,price,cod_fee,cod_status,shipping_type,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,orders.title,orders.pic_path,orders.price,orders.num,orders.iid,orders.num_iid,orders.sku_id,orders.refund_status,orders.status,orders.oid,orders.total_fee,orders.payment,orders.discount_fee,orders.adjust_fee,orders.sku_properties_name,orders.item_meal_name,orders.buyer_rate,orders.seller_rate,orders.outer_iid,orders.outer_sku_id,orders.refund_id,orders.seller_type";

            rep.Tid = long.Parse(tid);
            return client.Execute(rep, sessionKey);
        }

        /// <summary>
        ///  LogisticsOnlineSendResponse
        /// </summary>
        /// <param name="StartCreated">开始时间</param>
        /// <param name="EndCreated">结束时间</param>
        /// <returns></returns>
        public TradeSnapshotGetResponse TradeSnapshot(string tid)
        {
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            TradeSnapshotGetRequest rep = new TradeSnapshotGetRequest();
            rep.Fields = "seller_nick,buyer_nick,title,type,created,sid,tid,seller_rate,buyer_rate,status,payment,discount_fee,adjust_fee,post_fee,total_fee,pay_time,end_time,modified,consign_time,buyer_obtain_point_fee,point_fee,real_point_fee,received_payment,commission_fee,pic_path,num_iid,num_iid,num,price,cod_fee,cod_status,shipping_type,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,orders.title,orders.pic_path,orders.price,orders.num,orders.iid,orders.num_iid,orders.sku_id,orders.refund_status,orders.status,orders.oid,orders.total_fee,orders.payment,orders.discount_fee,orders.adjust_fee,orders.sku_properties_name,orders.item_meal_name,orders.buyer_rate,orders.seller_rate,orders.outer_iid,orders.outer_sku_id,orders.refund_id,orders.seller_type";

            rep.Tid = long.Parse(tid);
            return client.Execute(rep, sessionKey);
        }





        /// <summary>
        ///  LogisticsOnlineSendResponse
        /// </summary>
        /// <param name="StartCreated">开始时间</param>
        /// <param name="EndCreated">结束时间</param>
        /// <returns></returns>
        public TraderatesGetResponse LogisticsAddressSearch()
        {
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            TraderatesGetRequest rep = new TraderatesGetRequest();
            rep.Fields = "tid,oid,role,nick,result,created,rated_nick,item_title,item_price,content,reply,num_iid ";
            rep.RateType = "get";
            rep.Role = "seller";
            return client.Execute(rep, sessionKey);
        }



        /// <summary>
        ///  taobaoTraderatesGet 搜索评价信息
        /// </summary>
        /// <param name="RateType"></param>
        /// <param name="Role"></param>
        /// <returns></returns>
        public TraderatesGetResponse TraderatesGet(string RateType, string Role, long PageNo, long PageSize, DateTime StartDate, DateTime EndDate)
        { 
            ITopClient client = new DefaultTopClient(gateway, appkey, appsecret);
            TraderatesGetRequest rep = new TraderatesGetRequest();
            rep.Fields = "tid,oid,role,nick,result,created,rated_nick,item_title,item_price,content,reply,num_iid ";
            rep.RateType = RateType;
            rep.Role = Role;
            rep.PageNo = PageNo;
            rep.PageSize = PageSize;
            rep.StartDate = StartDate;
            rep.EndDate = EndDate;
            rep.UseHasNext = true;
            return client.Execute(rep, sessionKey);
        }
    }
}