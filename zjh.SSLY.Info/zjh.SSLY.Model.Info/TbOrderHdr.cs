//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace zjh.SSLY.Model.Info
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbOrderHdr
    {
        public int ID { get; set; }
        public string OrderId { get; set; }
        public string BuyerNick { get; set; }
        public Nullable<int> Uid { get; set; }
        public Nullable<decimal> Payment { get; set; }
        public string ReceiverState { get; set; }
        public string ReceiverCity { get; set; }
        public string ReceiverDistrict { get; set; }
        public string ReceiverAddress { get; set; }
        public string ReceiverZip { get; set; }
        public string ReceiverMobile { get; set; }
        public string ReceiverPhone { get; set; }
        public System.DateTime CreateTime { get; set; }
        public bool Delete { get; set; }
        public Nullable<System.DateTime> PayTime { get; set; }
        public string Status { get; set; }
        public string Formno { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingFee { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public string Account { get; set; }
        public string ReceiverName { get; set; }
        public string TrackingNo { get; set; }
        public Nullable<decimal> CreditCardFee { get; set; }
        public string AlipayAccount { get; set; }
        public string Type { get; set; }
        public string TradeFrom { get; set; }
        public string Flag { get; set; }
        public string ReceiverTown { get; set; }
        public string PicPath { get; set; }
    }
}
