using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// HotelGetResponse.
    /// </summary>
    public class HotelGetResponse : TopResponse
    {
        /// <summary>
        /// ιεΊη»ζ
        /// </summary>
        [XmlElement("hotel")]
        public Hotel Hotel { get; set; }
    }
}
