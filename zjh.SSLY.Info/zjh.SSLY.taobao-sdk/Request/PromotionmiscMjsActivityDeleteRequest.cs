using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.promotionmisc.mjs.activity.delete
    /// </summary>
    public class PromotionmiscMjsActivityDeleteRequest : ITopRequest<PromotionmiscMjsActivityDeleteResponse>
    {
        /// <summary>
        /// 活动id。<br /> 支持最小值为：0
        /// </summary>
        public Nullable<long> ActivityId { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.promotionmisc.mjs.activity.delete";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("activity_id", this.ActivityId);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("activity_id", this.ActivityId);
            RequestValidator.ValidateMinValue("activity_id", this.ActivityId, 0);
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
