using System;
using System.Collections.Generic;
using Aliyun.Api.ECS.ECS20130110.Response;
using Top.Api.Util;
using Top.Api;

namespace Aliyun.Api.ECS.ECS20130110.Request
{	
    
    /// <summary>
    /// TOP API: ecs.aliyuncs.com.DescribeSecurityGroups.2013-01-10
    /// </summary>
    public class DescribeSecurityGroupsRequest : IAliyunRequest<DescribeSecurityGroupsResponse>
    {
        /// <summary>
        /// 当前页码，起始值为1，默认值为1<br /> 支持最小值为：1
        /// </summary>
        public Nullable<long> PageNumber { get; set; }

        /// <summary>
        /// 分页查询时设置的每页行数，最大值50，默认值为10<br /> 支持最大值为：50
        /// </summary>
        public Nullable<long> PageSize { get; set; }

        /// <summary>
        /// 数据中心id
        /// </summary>
        public string RegionId { get; set; }

    
    	/// <summary>
    	///仅用于渠道商发起API调用时，指定访问的资源拥有者的ID
    	/// </summary>
        public string OwnerId { get; set; }
        
        /// <summary>
    	///仅用于渠道商发起API调用时，指定访问的资源拥有者的账号
    	/// </summary>
    	public string OwnerAccount { get; set; }
    	
    	/// <summary>
    	///API调用者试图通过API调用来访问别人拥有但已经授权给他的资源时，通过使用该参数来声明此次操作涉及到的资源是谁名下的.该参数仅官网用户可用
    	/// </summary>
    	public string ResourceOwnerAccount { get; set; }
    	
        private IDictionary<string, string> otherParameters;

        #region IAliyunRequest Members

        public string GetApiName()
        {
            return "ecs.aliyuncs.com.DescribeSecurityGroups.2013-01-10";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("OwnerId", this.OwnerId);
            parameters.Add("OwnerAccount", this.OwnerAccount);
            parameters.Add("ResourceOwnerAccount", this.ResourceOwnerAccount);
            parameters.Add("PageNumber", this.PageNumber);
            parameters.Add("PageSize", this.PageSize);
            parameters.Add("RegionId", this.RegionId);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateMinValue("PageNumber", this.PageNumber, 1);
            RequestValidator.ValidateMaxValue("PageSize", this.PageSize, 50);
            RequestValidator.ValidateRequired("RegionId", this.RegionId);
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
