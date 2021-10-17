using System;
using System.Xml.Serialization;
using Top.Api;

namespace Aliyun.Api.Domain
{
    /// <summary>
    /// Image Data Structure.
    /// </summary>
    [Serializable]
    public class Image : TopObject
    {
        /// <summary>
        /// 操作系统位数
        /// </summary>
        [XmlElement("Architecture")]
        public string Architecture { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [XmlElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// 镜像ID
        /// </summary>
        [XmlElement("ImageId")]
        public string ImageId { get; set; }

        /// <summary>
        /// 镜像名称
        /// </summary>
        [XmlElement("ImageName")]
        public string ImageName { get; set; }

        /// <summary>
        /// 镜像所有者
        /// </summary>
        [XmlElement("ImageOwnerAlias")]
        public string ImageOwnerAlias { get; set; }

        /// <summary>
        /// 镜像版本
        /// </summary>
        [XmlElement("ImageVersion")]
        public string ImageVersion { get; set; }

        /// <summary>
        /// 操作系统名称
        /// </summary>
        [XmlElement("OSName")]
        public string OSName { get; set; }

        /// <summary>
        /// 平台
        /// </summary>
        [XmlElement("Platform")]
        public string Platform { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        [XmlElement("Size")]
        public long Size { get; set; }

        /// <summary>
        /// 可见性
        /// </summary>
        [XmlElement("Visibility")]
        public string Visibility { get; set; }
    }
}
