using System;
using System.Xml.Serialization;

namespace Top.Api.Domain
{
    /// <summary>
    /// TripFlightPassenger Data Structure.
    /// </summary>
    [Serializable]
    public class TripFlightPassenger : TopObject
    {
        /// <summary>
        /// 乘机人生日：yyyy-mm-dd
        /// </summary>
        [XmlElement("birthday")]
        public string Birthday { get; set; }

        /// <summary>
        /// 舱位等级：0，头等舱(F)；1，商务舱(C)；2，经济舱(Y)
        /// </summary>
        [XmlElement("cabin_class")]
        public long CabinClass { get; set; }

        /// <summary>
        /// 航班舱位代码
        /// </summary>
        [XmlElement("cabin_code")]
        public string CabinCode { get; set; }

        /// <summary>
        /// 乘机人证件号码
        /// </summary>
        [XmlElement("cert_no")]
        public string CertNo { get; set; }

        /// <summary>
        /// 乘机人证件类型：0，身份证；1，护照；3，军人证；4，回乡证；5，台胞证；6，港澳台胞；10，警官证；11，士兵证件
        /// </summary>
        [XmlElement("cert_type")]
        public long CertType { get; set; }

        /// <summary>
        /// ei项
        /// </summary>
        [XmlElement("ei")]
        public string Ei { get; set; }

        /// <summary>
        /// 扩展字段
        /// </summary>
        [XmlElement("extra")]
        public string Extra { get; set; }

        /// <summary>
        /// 航班机建费，单位：分
        /// </summary>
        [XmlElement("fee")]
        public long Fee { get; set; }

        /// <summary>
        /// 强制保险金额，单位：分
        /// </summary>
        [XmlElement("force_insure_price")]
        public long ForceInsurePrice { get; set; }

        /// <summary>
        /// 当前乘机人的保险分润金额，单位：分
        /// </summary>
        [XmlElement("insure_promotion_price")]
        public long InsurePromotionPrice { get; set; }

        /// <summary>
        /// 备注信息，政策中的备注信息
        /// </summary>
        [XmlElement("memo")]
        public string Memo { get; set; }

        /// <summary>
        /// 乘机人姓名
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// 乘机人类型：0，成人；1，儿童；
        /// </summary>
        [XmlElement("passenger_type")]
        public long PassengerType { get; set; }

        /// <summary>
        /// PNR信息
        /// </summary>
        [XmlElement("pnr")]
        public string Pnr { get; set; }

        /// <summary>
        /// 政策id，淘宝系统政策唯一键
        /// </summary>
        [XmlElement("policy_id")]
        public long PolicyId { get; set; }

        /// <summary>
        /// 机票政策类型：0，默认；1，自定义
        /// </summary>
        [XmlElement("policy_type")]
        public long PolicyType { get; set; }

        /// <summary>
        /// 销售价格，单位：分
        /// </summary>
        [XmlElement("price")]
        public long Price { get; set; }

        /// <summary>
        /// 航班燃油税，单位：分
        /// </summary>
        [XmlElement("tax")]
        public long Tax { get; set; }

        /// <summary>
        /// 票号
        /// </summary>
        [XmlElement("ticket_no")]
        public string TicketNo { get; set; }

        /// <summary>
        /// 常旅客卡号
        /// </summary>
        [XmlElement("trip_card_no")]
        public string TripCardNo { get; set; }

        /// <summary>
        /// 退改签
        /// </summary>
        [XmlElement("tuigaiqian")]
        public string Tuigaiqian { get; set; }
    }
}
