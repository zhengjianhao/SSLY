using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryInitialResponse.
    /// </summary>
    public class InventoryInitialResponse : TopResponse
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        [XmlArray("tip_infos")]
        [XmlArrayItem("tip_info")]
        public List<TipInfo> TipInfos { get; set; }
    }
}
