using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// HotelAddResponse.
    /// </summary>
    public class HotelAddResponse : TopResponse
    {
        /// <summary>
        /// ιεΊη»ζ
        /// </summary>
        [XmlElement("hotel")]
        public Hotel Hotel { get; set; }
    }
}
