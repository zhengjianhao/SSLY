using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// FenxiaoDiscountUpdateResponse.
    /// </summary>
    public class FenxiaoDiscountUpdateResponse : TopResponse
    {
        /// <summary>
        /// ζεηΆζ
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
    }
}
