using System;
using System.Xml.Serialization;

namespace Top.Api.Response
{
    /// <summary>
    /// WeikePerformancePutResponse.
    /// </summary>
    public class WeikePerformancePutResponse : TopResponse
    {
        /// <summary>
        /// θΏεη»ζ
        /// </summary>
        [XmlElement("result")]
        public bool Result { get; set; }
    }
}
