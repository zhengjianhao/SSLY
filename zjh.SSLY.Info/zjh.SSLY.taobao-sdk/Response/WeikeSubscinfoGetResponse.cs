using System;
using System.Xml.Serialization;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// WeikeSubscinfoGetResponse.
    /// </summary>
    public class WeikeSubscinfoGetResponse : TopResponse
    {
        /// <summary>
        /// θΏεη»ζ
        /// </summary>
        [XmlElement("result")]
        public SubscInfoWrapper Result { get; set; }
    }
}
