using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.simba.rpt.campaigneffect.get
    /// </summary>
    public class SimbaRptCampaigneffectGetRequest : ITopRequest<SimbaRptCampaigneffectGetResponse>
    {
        /// <summary>
        /// 推广计划id
        /// </summary>
        public Nullable<long> CampaignId { get; set; }

        /// <summary>
        /// 结束时间，格式yyyy-mm-dd
        /// </summary>
        public string EndTime { get; set; }

        /// <summary>
        /// 昵称
        /// </summary>
        public string Nick { get; set; }

        /// <summary>
        /// 页码<br /> 支持最小值为：1
        /// </summary>
        public Nullable<long> PageNo { get; set; }

        /// <summary>
        /// 每页大小<br /> 支持最小值为：1
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 报表类型（搜索：SEARCH,类目出价：CAT,  定向投放：NOSEARCH 全部：ALL）可以一次取多个例如：SEARCH,CAT
        /// </summary>
        public string SearchType { get; set; }

        /// <summary>
        /// 数据来源（站内：1，站外：2）可多选以逗号分隔，默认值为：1,2
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 开始时间，格式yyyy-mm-dd
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 权限校验参数
        /// </summary>
        public string SubwayToken { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.simba.rpt.campaigneffect.get";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("campaign_id", this.CampaignId);
            parameters.Add("end_time", this.EndTime);
            parameters.Add("nick", this.Nick);
            parameters.Add("page_no", this.PageNo);
            parameters.Add("page_size", this.PageSize);
            parameters.Add("search_type", this.SearchType);
            parameters.Add("source", this.Source);
            parameters.Add("start_time", this.StartTime);
            parameters.Add("subway_token", this.SubwayToken);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("campaign_id", this.CampaignId);
            RequestValidator.ValidateRequired("end_time", this.EndTime);
            RequestValidator.ValidateMinValue("page_no", this.PageNo, 1);
            RequestValidator.ValidateMinValue("page_size", this.PageSize, 1);
            RequestValidator.ValidateRequired("search_type", this.SearchType);
            RequestValidator.ValidateRequired("source", this.Source);
            RequestValidator.ValidateRequired("start_time", this.StartTime);
            RequestValidator.ValidateRequired("subway_token", this.SubwayToken);
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
