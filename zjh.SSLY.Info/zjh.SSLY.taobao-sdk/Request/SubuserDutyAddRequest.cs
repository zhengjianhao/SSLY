using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.subuser.duty.add
    /// </summary>
    public class SubuserDutyAddRequest : ITopRequest<SubuserDutyAddResponse>
    {
        /// <summary>
        /// 职务级别
        /// </summary>
        public Nullable<long> DutyLevel { get; set; }

        /// <summary>
        /// 职务名称
        /// </summary>
        public string DutyName { get; set; }

        /// <summary>
        /// 主账号用户名
        /// </summary>
        public string UserNick { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.subuser.duty.add";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("duty_level", this.DutyLevel);
            parameters.Add("duty_name", this.DutyName);
            parameters.Add("user_nick", this.UserNick);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("duty_level", this.DutyLevel);
            RequestValidator.ValidateRequired("duty_name", this.DutyName);
            RequestValidator.ValidateRequired("user_nick", this.UserNick);
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
