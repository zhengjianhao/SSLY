using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallEaiOrderRefundGoodReturnGetResponse.
    /// </summary>
    public class TmallEaiOrderRefundGoodReturnGetResponse : TopResponse
    {
        /// <summary>
        /// ้่ดงๅ
        /// </summary>
        [XmlElement("return_bill")]
        public ReturnBill ReturnBill { get; set; }
    }
}
