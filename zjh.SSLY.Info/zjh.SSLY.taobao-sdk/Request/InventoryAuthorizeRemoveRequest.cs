using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.inventory.authorize.remove
    /// </summary>
    public class InventoryAuthorizeRemoveRequest : ITopRequest<InventoryAuthorizeRemoveResponse>
    {
        /// <summary>
        /// 库存授权结果码
        /// </summary>
        public string AuthorizeCode { get; set; }

        /// <summary>
        /// 后端商品id
        /// </summary>
        public Nullable<long> ScItemId { get; set; }

        /// <summary>
        /// 移除授权的目标用户昵称列表，用”,”隔开
        /// </summary>
        public string UserNickList { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.inventory.authorize.remove";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("authorize_code", this.AuthorizeCode);
            parameters.Add("sc_item_id", this.ScItemId);
            parameters.Add("user_nick_list", this.UserNickList);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("authorize_code", this.AuthorizeCode);
            RequestValidator.ValidateRequired("sc_item_id", this.ScItemId);
            RequestValidator.ValidateRequired("user_nick_list", this.UserNickList);
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
