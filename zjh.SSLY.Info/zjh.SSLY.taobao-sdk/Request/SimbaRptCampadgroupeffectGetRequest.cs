using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.simba.rpt.campadgroupeffect.get
    /// </summary>
    public class SimbaRptCampadgroupeffectGetRequest : ITopRequest<SimbaRptCampadgroupeffectGetResponse>
    {
        /// <summary>
        /// 查询推广计划id
        /// </summary>
        public Nullable<long> CampaignId { get; set; }

        /// <summary>
        /// 结束日期，格式yyyy-mm-dd
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
        /// 报表类型（搜索：SEARCH,类目出价：CAT, 定向投放：NOSEARCH汇总：SUMMARY）SUMMARY必须单选，其他值可多选例如：SEARCH,CAT
        /// </summary>
        public string SearchType { get; set; }

        /// <summary>
        /// 数据来源（站内：1，站外：2 ，汇总：SUMMARY）SUMMARY必须单选，其他值可多选例如1,2
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 开始日期，格式yyyy-mm-dd
        /// </summary>
        public string StartTime { get; set; }

        /// <summary>
        /// 权限验证信息
        /// </summary>
        public string SubwayToken { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.simba.rpt.campadgroupeffect.get";
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
