using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// TmallEaiOrderRefundGoodReturnRefuseResponse.
    /// </summary>
    public class TmallEaiOrderRefundGoodReturnRefuseResponse : TopResponse
    {
        /// <summary>
        /// θΏεη»ζ
        /// </summary>
        [XmlElement("is_success")]
        public bool IsSuccess { get; set; }
    }
}
