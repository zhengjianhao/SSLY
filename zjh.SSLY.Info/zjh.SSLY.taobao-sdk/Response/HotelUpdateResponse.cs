using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// HotelUpdateResponse.
    /// </summary>
    public class HotelUpdateResponse : TopResponse
    {
        /// <summary>
        /// ιεΊη»ζ
        /// </summary>
        [XmlElement("hotel")]
        public Hotel Hotel { get; set; }
    }
}
