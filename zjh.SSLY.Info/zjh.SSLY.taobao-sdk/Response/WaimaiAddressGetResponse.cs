using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// WaimaiAddressGetResponse.
    /// </summary>
    public class WaimaiAddressGetResponse : TopResponse
    {
        /// <summary>
        /// θΏεη»ζ
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }
    }
}
