using System;
using System.Collections.Generic;
using Top.Api.Response;
using Top.Api.Util;

namespace Top.Api.Request
{
    /// <summary>
    /// TOP API: taobao.travel.items.update
    /// </summary>
    public class TravelItemsUpdateRequest : ITopUploadRequest<TravelItemsUpdateResponse>
    {
        /// <summary>
        /// 套餐价格日历增量更新字段，添加若干新套餐。（说明：如果使用增量更新字段，则全量更新字段combo_price_calendar不用设置，如果设置了则会优先使用全量更新），套餐价格日历json格式。如：{"combos":[{"combo_name":"套餐一","price_calendar":[{"child_num":100,"child_price":100,"date":"2012-06-08","diff_price":1000,"man_num":100,"man_price":1000},{"child_num":100,"child_price":100,"date":"2012-06-09","diff_price":1000,"man_num":100,"man_price":1000}]}]}
        /// </summary>
        public string AddComboPriceCalendar { get; set; }

        /// <summary>
        /// 商品上传后的状态。可选值:onsale(出售中),instock(仓库中);默认值:onsale。
        /// </summary>
        public string ApproveStatus { get; set; }

        /// <summary>
        /// 商品的积分返点比例。如:5,表示:返点比例0.5%. 注意：返点比例必须是>0的整数.
        /// </summary>
        public Nullable<long> AuctionPoint { get; set; }

        /// <summary>
        /// 发布电子凭证宝贝时候表示是否使用邮寄 0: 代表不使用邮寄； 1：代表使用邮寄；如果不设置这个值，代表不使用邮寄。
        /// </summary>
        public string ChooseLogis { get; set; }

        /// <summary>
        /// 商品所属类目ID。发布旅游线路商品有两个值：1(国内线路类目ID)，2(国际线路类目ID)。
        /// </summary>
        public Nullable<long> Cid { get; set; }

        /// <summary>
        /// 宝贝所在地市。如果发布旅游度假线路的宝贝，该字段可以忽略。
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Json串，全量更新套餐价格日历信息（针对旅游度假线路的销售属性），定义了两个套餐日历价格，套餐明分别为：套餐一和套餐二。如：{"combos":[{"combo_name":"套餐一","price_calendar":[{"child_num":100,"child_price":100,"date":"2012-06-08","diff_price":1000,"man_num":100,"man_price":1000},{"child_num":100,"child_price":100,"date":"2012-06-09","diff_price":1000,"man_num":100,"man_price":1000}]}]}
        /// </summary>
        public string ComboPriceCalendar { get; set; }

        /// <summary>
        /// 商品描述，不超过50000个字符。
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 最晚成团提前天数，最小0天，最大为300天。
        /// </summary>
        public Nullable<long> Duration { get; set; }

        /// <summary>
        /// 支持宝贝信息的删除，各个参数的名称之间用【,】分割, 如果对应的参数有设置过值，即使在这个列表中，也不会被删除; 目前支持此功能的宝贝信息如下：locality_life表示删除电子凭证，merchant表示删除码商信息，refund_ratio表示删除电子凭证退款比例，network_id表示删除电子凭证网点信息,seller_cids表示删除关联店铺类目，outer_id表示删除商家外部编码，second_kill表示删除秒杀信息，input_pids表示删除用户自定义属性
        /// </summary>
        public string EmptyFields { get; set; }

        /// <summary>
        /// 电子交易凭证有效期，目前此字段只涉及到的信息为有效期; 如果有效期为起止日期类型，此值为2012-08-06,2012-08-16 如果有效期为【购买成功日 至】类型则格式为2012-08-16 如果有效期为天数类型则格式为15。
        /// </summary>
        public string Expirydate { get; set; }

        /// <summary>
        /// 费用包含，不超过1500个字符。
        /// </summary>
        public string FeeInclude { get; set; }

        /// <summary>
        /// 费用不包，不超过1500个字符。
        /// </summary>
        public string FeeNotInclude { get; set; }

        /// <summary>
        /// 机票信息，不超过1500字符
        /// </summary>
        public string FlightInfo { get; set; }

        /// <summary>
        /// 集合地，不超过30个字符。
        /// </summary>
        public string GatheringPlace { get; set; }

        /// <summary>
        /// 支持会员打折。可选值:true,false;默认值:false(不打折)。
        /// </summary>
        public Nullable<bool> HasDiscount { get; set; }

        /// <summary>
        /// 是否有发票。可选值:true,false (商城卖家此字段必须为true);默认值:false(无发票)。
        /// </summary>
        public Nullable<bool> HasInvoice { get; set; }

        /// <summary>
        /// 橱窗推荐。可选值:true,false;默认值:false(不推荐)，B商家不用设置该字段，均为true。
        /// </summary>
        public Nullable<bool> HasShowcase { get; set; }

        /// <summary>
        /// 酒店信息，不超过1500字符
        /// </summary>
        public string HotelInfo { get; set; }

        /// <summary>
        /// 商品主图。类型:JPG,GIF;最大长度:500k，支持的文件类型：gif,jpg,jpeg,png。
        /// </summary>
        public FileItem Image { get; set; }

        /// <summary>
        /// 用户自行输入的类目属性ID串。结构："pid1,pid2,pid3"，如："2000"（表示品牌） 注：通常一个类目下用户可输入的关键属性不超过1个。在度假线路类目中，该属性ID为“自由行包含元素”或“一日游包含元素”属性ID。
        /// </summary>
        public string InputPids { get; set; }

        /// <summary>
        /// 用户自行输入的子属性名和属性值，如“自定义自由行包含元素”。
        /// </summary>
        public string InputStr { get; set; }

        /// <summary>
        /// 是否是铁定出游商品
        /// </summary>
        public Nullable<bool> IsTdcy { get; set; }

        /// <summary>
        /// 商品数字ID。
        /// </summary>
        public Nullable<long> ItemId { get; set; }

        /// <summary>
        /// 码商信息，格式为 码商id:nick。
        /// </summary>
        public string Merchant { get; set; }

        /// <summary>
        /// 网点ID。
        /// </summary>
        public string NetworkId { get; set; }

        /// <summary>
        /// 商品库存。如果发布旅游度假线路宝贝，该字段可以忽略，参考后面：add_combo_price_calendar,update_combo_price_calendar,remove_combo_price_calendar 这些字段去使用商品销售属性
        /// </summary>
        public Nullable<long> Num { get; set; }

        /// <summary>
        /// 电子凭证售中自动退款比例，百分比%前的数字，介于1-100之间的整数。
        /// </summary>
        public Nullable<long> OnsaleAutoRefundRatio { get; set; }

        /// <summary>
        /// 预定须知，不超过1500个字符。
        /// </summary>
        public string OrderInfo { get; set; }

        /// <summary>
        /// 商家的外部编码，最大为512字节。
        /// </summary>
        public string OuterId { get; set; }

        /// <summary>
        /// 自费项目，不超过1500个字符。
        /// </summary>
        public string OwnExpense { get; set; }

        /// <summary>
        /// 商品主图需要关联的图片空间的相对url。这个url所对应的图片必须要属于当前用户。pic_path和image只需要传入一个,如果两个都传，默认选择pic_path。
        /// </summary>
        public string PicPath { get; set; }

        /// <summary>
        /// 商品一口价。如果发布旅游度假线路宝贝，该字段可以忽略，参考后面：add_combo_price_calendar,update_combo_price_calendar,remove_combo_price_calendar 这些字段去使用商品销售属性
        /// </summary>
        public Nullable<long> Price { get; set; }

        /// <summary>
        /// 商品属性列表。格式为：pid:vid;pid:vid。例如发布旅游度假线路商品，那么这里就需要填写：出发地属性id:城市id;目的地市属性id:目的地市id;……等等。
        /// </summary>
        public string Props { get; set; }

        /// <summary>
        /// 宝贝所在地省份。如果发布旅游线路宝贝，该字段可以忽略。
        /// </summary>
        public string Prov { get; set; }

        /// <summary>
        /// 退款比例，百分比%前的数字,1-100的正整数值。
        /// </summary>
        public Nullable<long> RefundRatio { get; set; }

        /// <summary>
        /// 退改规定，不超过1500个字符。
        /// </summary>
        public string RefundRegulation { get; set; }

        /// <summary>
        /// 套餐价格日历增量更新字段，删除若干套餐。（说明：如果使用增量更新字段，则全量更新字段combo_price_calendar不用设置，如果设置了则会优先使用全量更新）。删除时，需要设置套餐属性id（pid），套餐属性值id（vid）。格式为：pid:vid1;pid:vid2;pid:vid3。
        /// </summary>
        public string RemoveComboPriceCalendar { get; set; }

        /// <summary>
        /// 商品属性（不包含销售属性）增量更新字段，删除商品属性。（说明：如果使用增量更新字段，则全量更新字段props不用设置，如果设置了则会优先使用全量更新）。格式：pid1:vid1;pid2:vid2;pid3:vid3。
        /// </summary>
        public string RemoveProps { get; set; }

        /// <summary>
        /// 商品秒杀三个值：可选类型web_only(只能通过web网络秒杀)，wap_only(只能通过wap网络秒杀)，web_and_wap(既能通过web秒杀也能通过wap秒杀)。
        /// </summary>
        public string SecondKill { get; set; }

        /// <summary>
        /// 关联商品与店铺类目，结构:",cid1,cid2,...,"，如果店铺类目存在二级类目，必须传入子类目cids。
        /// </summary>
        public string SellerCids { get; set; }

        /// <summary>
        /// 购物店信息，不超过1500个字符。
        /// </summary>
        public string ShopingInfo { get; set; }

        /// <summary>
        /// Sku销售属性串对应的价格，每一个属性串都会对应一个价格，精确到两位小数，单位为元。sku_prices的数组大小应该和sku_properties的数组大小一致。如果发布线路的商品，参考后面：add_combo_price_calendar,update_combo_price_calendar,remove_combo_price_calendar 这些字段去使用商品销售属性
        /// </summary>
        public string SkuPrices { get; set; }

        /// <summary>
        /// Sku销售属性串，调用taobao.travel.itemsprops.get接口获取商品销售属性code，然后拼接成pid:vid;pid:vid格式。如果发布线路的商品，参考后面：add_combo_price_calendar,update_combo_price_calendar,remove_combo_price_calendar 这些字段去使用商品销售属性
        /// </summary>
        public string SkuProperties { get; set; }

        /// <summary>
        /// Sku销售属性串对应的库存，每一个属性串都会对应一个库存，显然sku_quantities的数组大小应该和sku_properties的数组大小一致。如果发布线路的商品，参考后面：add_combo_price_calendar,update_combo_price_calendar,remove_combo_price_calendar 这些字段去使用商品销售属性
        /// </summary>
        public string SkuQuantities { get; set; }

        /// <summary>
        /// 商品是否支持拍下减库存:1支持;2取消支持(付款减库存);0(默认)不更改，集市卖家默认拍下减库存;商城卖家默认付款减库存。
        /// </summary>
        public Nullable<long> SubStock { get; set; }

        /// <summary>
        /// 门票信息，不超过1500字符
        /// </summary>
        public string TicketInfo { get; set; }

        /// <summary>
        /// 商品标题。注意：在商品更新时，如果不设置该属性，默认不进行更新，下同。
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 否 套餐价格日历增量更新字段，更新若干套餐。（说明：如果使用增量更新字段，则全量更新字段combo_price_calendar不用设置，如果设置了则会优先使用全量更新），套餐价格日历json格式。更新时，需要设置套餐属性id（pid），套餐属性值id（vid），套餐名称可以不设置，设置了也会忽略，会以传入的pid和vid为准。如：{"combos":[{"combo_name":"套餐一","pid":102020,"vid":289129,"price_calendar":[{"child_num":100,"child_price":100,"date":"2012-06-08","diff_price":1000,"man_num":100,"man_price":1000},{"child_num":100,"child_price":100,"date":"2012-06-09","diff_price":1000,"man_num":100,"man_price":1000}]}]}
        /// </summary>
        public string UpdateComboPriceCalendar { get; set; }

        /// <summary>
        /// 商品属性（不包含销售属性）增量更新字段，更新或者添加商品属性。（说明：如果使用增量更新字段，则全量更新字段props不用设置，如果设置了则会优先使用全量更新）。格式：pid1:vid1;pid2:vid2;pid3:vid3。对于重复设置的同一个属性的多个值，对于单选属性，则会以最后一个为准；对于多选，则会对该属性新增属性值。
        /// </summary>
        public string UpdateOrAddProps { get; set; }

        /// <summary>
        /// 核销打款 1代表核销打款 0代表非核销打款。
        /// </summary>
        public string Verification { get; set; }

        private IDictionary<string, string> otherParameters;

        #region ITopRequest Members

        public string GetApiName()
        {
            return "taobao.travel.items.update";
        }

        public IDictionary<string, string> GetParameters()
        {
            TopDictionary parameters = new TopDictionary();
            parameters.Add("add_combo_price_calendar", this.AddComboPriceCalendar);
            parameters.Add("approve_status", this.ApproveStatus);
            parameters.Add("auction_point", this.AuctionPoint);
            parameters.Add("choose_logis", this.ChooseLogis);
            parameters.Add("cid", this.Cid);
            parameters.Add("city", this.City);
            parameters.Add("combo_price_calendar", this.ComboPriceCalendar);
            parameters.Add("desc", this.Desc);
            parameters.Add("duration", this.Duration);
            parameters.Add("empty_fields", this.EmptyFields);
            parameters.Add("expirydate", this.Expirydate);
            parameters.Add("fee_include", this.FeeInclude);
            parameters.Add("fee_not_include", this.FeeNotInclude);
            parameters.Add("flight_info", this.FlightInfo);
            parameters.Add("gathering_place", this.GatheringPlace);
            parameters.Add("has_discount", this.HasDiscount);
            parameters.Add("has_invoice", this.HasInvoice);
            parameters.Add("has_showcase", this.HasShowcase);
            parameters.Add("hotel_info", this.HotelInfo);
            parameters.Add("input_pids", this.InputPids);
            parameters.Add("input_str", this.InputStr);
            parameters.Add("is_tdcy", this.IsTdcy);
            parameters.Add("item_id", this.ItemId);
            parameters.Add("merchant", this.Merchant);
            parameters.Add("network_id", this.NetworkId);
            parameters.Add("num", this.Num);
            parameters.Add("onsale_auto_refund_ratio", this.OnsaleAutoRefundRatio);
            parameters.Add("order_info", this.OrderInfo);
            parameters.Add("outer_id", this.OuterId);
            parameters.Add("own_expense", this.OwnExpense);
            parameters.Add("pic_path", this.PicPath);
            parameters.Add("price", this.Price);
            parameters.Add("props", this.Props);
            parameters.Add("prov", this.Prov);
            parameters.Add("refund_ratio", this.RefundRatio);
            parameters.Add("refund_regulation", this.RefundRegulation);
            parameters.Add("remove_combo_price_calendar", this.RemoveComboPriceCalendar);
            parameters.Add("remove_props", this.RemoveProps);
            parameters.Add("second_kill", this.SecondKill);
            parameters.Add("seller_cids", this.SellerCids);
            parameters.Add("shoping_info", this.ShopingInfo);
            parameters.Add("sku_prices", this.SkuPrices);
            parameters.Add("sku_properties", this.SkuProperties);
            parameters.Add("sku_quantities", this.SkuQuantities);
            parameters.Add("sub_stock", this.SubStock);
            parameters.Add("ticket_info", this.TicketInfo);
            parameters.Add("title", this.Title);
            parameters.Add("update_combo_price_calendar", this.UpdateComboPriceCalendar);
            parameters.Add("update_or_add_props", this.UpdateOrAddProps);
            parameters.Add("verification", this.Verification);
            parameters.AddAll(this.otherParameters);
            return parameters;
        }

        public void Validate()
        {
            RequestValidator.ValidateRequired("item_id", this.ItemId);
            RequestValidator.ValidateMaxListSize("seller_cids", this.SellerCids, 20);
            RequestValidator.ValidateMaxListSize("sku_prices", this.SkuPrices, 20);
            RequestValidator.ValidateMaxListSize("sku_properties", this.SkuProperties, 20);
            RequestValidator.ValidateMaxListSize("sku_quantities", this.SkuQuantities, 20);
        }

        #endregion

        #region ITopUploadRequest Members

        public IDictionary<string, FileItem> GetFileParameters()
        {
            IDictionary<string, FileItem> parameters = new Dictionary<string, FileItem>();
            parameters.Add("image", this.Image);
            return parameters;
        }

        #endregion

        public void AddOtherParameter(string key, string value)
        {
            if (this.otherParameters == null)
            {
                this.otherParameters = new TopDictionary();
            }
            this.otherParameters.Add(key, value);
        }
    }
}
