using System;
using System.Xml.Serialization;
using Top.Api;

namespace Aliyun.Api.Domain
{
    /// <summary>
    /// SecurityGroup Data Structure.
    /// </summary>
    [Serializable]
    public class SecurityGroup : TopObject
    {
        /// <summary>
        /// 安全组描述信息
        /// </summary>
        [XmlElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 安全组ID
        /// </summary>
        [XmlElement("SecurityGroupId")]
        public string SecurityGroupId { get; set; }
    }
}
