using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using Top.Api.Domain;

namespace Top.Api.Response
{
    /// <summary>
    /// InventoryStoreManageResponse.
    /// </summary>
    public class InventoryStoreManageResponse : TopResponse
    {
        /// <summary>
        /// θΏεη»ζ
        /// </summary>
        [XmlArray("store_list")]
        [XmlArrayItem("store")]
        public List<Store> StoreList { get; set; }
    }
}
