using System;
using System.Collections.Generic;
using Aliyun.Api.ECS.ECS20130110.Response;
using Top.Api.Util;
using Top.Api;

namespace Aliyun.Api.ECS.ECS20130110.Request
{	
    
    /// <summary>
    /// TOP API: ecs.aliyuncs.com.CreateSnapshot.2013-01-10
    /// </summary>
    public class CreateSnapshotRequest : IAliyunRequest<CreateSnapshotResponse>
    {
        /// <summary>
        /// 用于保证请求的幂等性。由客户端生成该参数值，要保证在不同请求间唯一，最大不值过64个ASCII字符。 具体参见附录：如何保证幂等性。
        /// </summary>
        public string ClientToken { get; set; }

        /// <summary>
        /// 指定的磁盘ID
        /// </summary>
        public string DiskId { get; set; }

        /// <summary>
        /// 指定的实例ID
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// 快照的显示名称，由字母、数字、"-"组成，长度取值范围为[0,300]
        /// </summary>
        public string SnapshotName { get; set; }

    
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
            return "ecs.aliyuncs.com.CreateSnapshot.2013-01-10";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("OwnerId", this.OwnerId);
            parameters.Add("OwnerAccount", this.OwnerAccount);
            parameters.Add("ResourceOwnerAccount", this.ResourceOwnerAccount);
            parameters.Add("ClientToken", this.ClientToken);
            parameters.Add("DiskId", this.DiskId);
            parameters.Add("InstanceId", this.InstanceId);
            parameters.Add("SnapshotName", this.SnapshotName);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("DiskId", this.DiskId);
            RequestValidator.ValidateRequired("InstanceId", this.InstanceId);
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
