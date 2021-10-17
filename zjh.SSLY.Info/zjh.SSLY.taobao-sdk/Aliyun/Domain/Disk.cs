using System;
using System.Xml.Serialization;
using Top.Api;

namespace Aliyun.Api.Domain
{
    /// <summary>
    /// Disk Data Structure.
    /// </summary>
    [Serializable]
    public class Disk : TopObject
    {
        /// <summary>
        /// 磁盘种类  可选值：cloud: 云磁盘，ephemeral: 临时磁盘
        /// </summary>
        [XmlElement("Category")]
        public string Category { get; set; }

        /// <summary>
        /// 磁盘ID
        /// </summary>
        [XmlElement("DiskId")]
        public string DiskId { get; set; }

        /// <summary>
        /// 磁盘大小，单位GB
        /// </summary>
        [XmlElement("Size")]
        public long Size { get; set; }

        /// <summary>
        /// 磁盘类型  可选值：system: 系统盘，data: 数据盘
        /// </summary>
        [XmlElement("Type")]
        public string Type { get; set; }
    }
}
