using System;
using System.Xml.Serialization;
using Top.Api;

namespace Aliyun.Api.Domain
{
    /// <summary>
    /// Snapshot Data Structure.
    /// </summary>
    [Serializable]
    public class Snapshot : TopObject
    {
        /// <summary>
        /// 快照创建时间
        /// </summary>
        [XmlElement("CreationTime")]
        public string CreationTime { get; set; }

        /// <summary>
        /// 快照完成进度
        /// </summary>
        [XmlElement("Progress")]
        public string Progress { get; set; }

        /// <summary>
        /// 快照ID
        /// </summary>
        [XmlElement("SnapshotId")]
        public string SnapshotId { get; set; }

        /// <summary>
        /// 快照名称
        /// </summary>
        [XmlElement("SnapshotName")]
        public string SnapshotName { get; set; }
    }
}
