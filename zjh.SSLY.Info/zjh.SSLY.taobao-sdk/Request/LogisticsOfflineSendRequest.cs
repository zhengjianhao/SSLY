using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.logistics.offline.send
    /// </summary>
    public class LogisticsOfflineSendRequest : ITopRequest<LogisticsOfflineSendResponse>
    {
        /// <summary>
        /// 卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。<br><font color='red'>如果为空，取的卖家的默认退货地址</font><br>
        /// </summary>
        public Nullable<long> CancelId { get; set; }

        /// <summary>
        /// 物流公司代码.如"POST"就代表中国邮政,"ZJS"就代表宅急送.调用 taobao.logistics.companies.get 获取。非淘宝官方物流合作公司，填写具体的物流公司名称，如“顺丰”。
        /// </summary>
        public string CompanyCode { get; set; }

        /// <summary>
        /// feature参数格式<br>  范例: identCode=tid1:识别码1,识别码2|tid2:识别码3;machineCode=tid3:3C机器号A,3C机器号B<br>  identCode为识别码的KEY,machineCode为3C的KEY,多个key之间用”;”分隔<br>  “tid1:识别码1,识别码2|tid2:识别码3”为identCode对应的value。  "|"不同商品间的分隔符。<br>  例1商品和2商品，之间就用"|"分开。<br>  TID就是商品代表的子订单号，对应taobao.trade.fullinfo.get 接口获得的oid字段。(通过OID可以唯一定位到当前商品上)<br>  ":"TID和具体传入参数间的分隔符。冒号前表示TID,之后代表该商品的参数属性。<br>  "," 属性间分隔符。（对应商品数量，当存在一个商品的数量超过1个时，用逗号分开）。<br>  具体:当订单中A商品的数量为2个，其中手机串号分别为"12345","67890"。<br>  参数格式：identCode=TIDA:12345,67890。  TIDA对应了A宝贝，冒号后用逗号分隔的"12345","67890".说明本订单A宝贝的数量为2，值分别为"12345","67890"。<br>  当存在"|"时，就说明订单中存在多个商品，商品间用"|"分隔了开来。|"之后的内容含义同上。
        /// </summary>
        public string Feature { get; set; }

        /// <summary>
        /// 表明是否是拆单 1表示拆单 0表示不拆单，默认值0
        /// </summary>
        public Nullable<long> IsSplit { get; set; }

        /// <summary>
        /// 运单号.具体一个物流公司的真实运单号码。淘宝官方物流会校验，请谨慎传入；若company_code中传入的代码非淘宝官方物流合作公司，此处运单号不校验。
        /// </summary>
        public string OutSid { get; set; }

        /// <summary>
        /// 商家的IP地址
        /// </summary>
        public string SellerIp { get; set; }

        /// <summary>
        /// 卖家联系人地址库ID，可以通过taobao.logistics.address.search接口查询到地址库ID。<font color='red'>如果为空，取的卖家的默认取货地址</font>
        /// </summary>
        public Nullable<long> SenderId { get; set; }

        /// <summary>
        /// 需要拆单发货的子订单集合，为空表示不做拆单发货。
        /// </summary>
        public string SubTid { get; set; }

        /// <summary>
        /// 淘宝交易ID<br /> 支持最小值为：1000
        /// </summary>
        public Nullable<long> Tid { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.logistics.offline.send";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("cancel_id", this.CancelId);
            parameters.Add("company_code", this.CompanyCode);
            parameters.Add("feature", this.Feature);
            parameters.Add("is_split", this.IsSplit);
            parameters.Add("out_sid", this.OutSid);
            parameters.Add("seller_ip", this.SellerIp);
            parameters.Add("sender_id", this.SenderId);
            parameters.Add("sub_tid", this.SubTid);
            parameters.Add("tid", this.Tid);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("company_code", this.CompanyCode);
            RequestValidator.ValidateRequired("out_sid", this.OutSid);
            RequestValidator.ValidateMaxListSize("sub_tid", this.SubTid, 50);
            RequestValidator.ValidateRequired("tid", this.Tid);
            RequestValidator.ValidateMinValue("tid", this.Tid, 1000);
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
