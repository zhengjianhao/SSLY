using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// HotelCityGetResponse.
    /// </summary>
    public class HotelCityGetResponse : TopResponse
    {
        /// <summary>
        /// θΏεη»ζ
        /// </summary>
        [XmlElement("result")]
        public string Result { get; set; }
    }
}
