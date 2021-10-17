using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.weitao.menu.create
    /// </summary>
    public class WeitaoMenuCreateRequest : ITopRequest<WeitaoMenuCreateResponse>
    {
        /// <summary>
        /// [{     "name": "来吧少年",     "sub_button": [     {         "features":          {             "3": "1388726770350003001",             "2": "1388726770350003001",             "1": "1388726770350003001",             "0": "1388726770350003001",             "4": "1388726770350003001"         },         "name": "来吧少年快点击",         "type": "click"     },     {         "name": "来吧少年新网面",         "type": "view",         "url": "http://www.taobao.com"     }] },  {     "name": "来吧妹纸",     "sub_button": [     {         "features":          {             "3": "1388726414653004002",             "2": "1388726414653004002",             "1": "1388726414653004002",             "0": "1388726414653004002",             "4": "1388726414653004002"         },         "name": "来吧妹纸快点",         "type": "click"     },      {         "name": "来吧妹纸新网页",         "type": "view",         "url": "http://www.taobao.com"     }]  },  {     "name": "阿加西",     "type": "view",     "url": "http://www.taobao.com" }]
        /// </summary>
        public string MenuString { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.weitao.menu.create";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("menu_string", this.MenuString);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("menu_string", this.MenuString);
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
