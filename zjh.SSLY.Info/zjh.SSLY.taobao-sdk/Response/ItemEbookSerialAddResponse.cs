using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// ItemEbookSerialAddResponse.
    /// </summary>
    public class ItemEbookSerialAddResponse : TopResponse
    {
        /// <summary>
        /// 商品结构,仅有numIid和created返回
        /// </summary>
        [XmlElement("item")]
        public Item Item { get; set; }
    }
}
