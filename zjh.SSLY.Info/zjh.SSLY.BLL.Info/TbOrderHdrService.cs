using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.DAL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    public partial class TbOrderHdrService : BaseService<TbOrderHdr>, ITbOrderHdrService
    {
        private string _result;
        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
            }
        }



        private ITbOrderHdrRepository dal = new TbOrderHdrRepository();
        public bool Save(TbOrderHdr hdr, List<TbOrderDtl> dtls)
        {
            ITbOrderDtlRepository dalDtl = new TbOrderDtlRepository();
            string formno = dal.Save(hdr);
            foreach (TbOrderDtl dtl in dtls)
            {
                dtl.Formno = formno;
                dtl.Sn = GetSn();
                dtl.Leave = dtl.Qty;
                dalDtl.AddEntity(dtl);
            }
            return dbSession.SaveChanges() > 0;

        }




        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="hdrs"></param>
        /// <param name="dtls"></param>
        /// <returns></returns>
        public void Save(DataTable hdrs, DataTable dtls)
        {
            foreach (DataRow rowhdr in hdrs.Rows)
            {
                string orderid = rowhdr["订单编号"].ToString().Replace("\"", "").Replace("=", "");
                var lihdrs = dal.LoadEntities(u => u.OrderId == orderid).ToList();
                if (lihdrs.Count > 0)
                {
                    var tbHdr = lihdrs[0];
                    tbHdr.Status = ConverStatus(rowhdr["订单状态"].ToString());
                    dal.UpdateEntity(tbHdr);
                    if (dbSession.SaveChanges() > 0)
                    {
                        continue;
                    }

                } 
                var rowdtls = dtls.AsEnumerable().Where(u => ConverObjToStr(u.Field<object>("订单编号")) == ConverObjToStr(rowhdr.Field<object>("订单编号"))).ToList();
                if (rowdtls.Count == 0)
                    continue;

                var hdr = ConverRowToHdr(rowhdr);
                List<TbOrderDtl> lidtls = new List<TbOrderDtl>();
                foreach (DataRow r in rowdtls)
                {
                    lidtls.Add(ConverRowToDtl(r, hdr));
                }
                bool _r = Save(hdr, lidtls);
            }
        }

        private string ConverObjToStr(object obj)
        {
            return obj.ToString();
        }

        private TbOrderHdr ConverRowToHdr(DataRow rowhdr)
        {
            TbOrderHdr hdr = new TbOrderHdr();
            hdr.OrderId = rowhdr["订单编号"].ToString().Replace("=", "").Replace("\"", "");

            hdr.BuyerNick = rowhdr["买家会员名"].ToString();
            hdr.Uid = 2;
            hdr.Payment = decimal.Parse(rowhdr["买家实际支付金额"].ToString());

            string[] receiver = rowhdr["收货地址 "].ToString().Split(' ');
            hdr.ReceiverState = receiver[0];
            hdr.ReceiverCity = receiver[1];
            hdr.ReceiverDistrict = receiver[2];
            for (int i = 0; i < receiver.Length; i++)
            {
                if (i > 2)
                {
                    hdr.ReceiverAddress += receiver[i];
                }
            }
            int _stark = hdr.ReceiverAddress.LastIndexOf('(');
            int _end = hdr.ReceiverAddress.LastIndexOf(')');

            string _rZip = hdr.ReceiverAddress.Substring(_stark, hdr.ReceiverAddress.Length - _stark);
            string zip = _rZip.Replace("(", "").Replace(")", "");
            hdr.ReceiverAddress = hdr.ReceiverAddress.Replace(_rZip, "");

            hdr.ReceiverZip = zip;


            hdr.ReceiverMobile = rowhdr["联系手机"].ToString().Replace("'", "");
            hdr.ReceiverPhone = rowhdr["联系电话 "].ToString().Replace("'", "");
            hdr.CreateTime = DateTime.Now;
            hdr.Delete = false;
            hdr.PayTime = DateTime.Parse(rowhdr["订单付款时间 "].ToString());
            hdr.Status = ConverStatus(rowhdr["订单状态"].ToString());

            hdr.TotalPrice = decimal.Parse(rowhdr["总金额"].ToString());
            hdr.ShippingFee = 0;
            hdr.OrderStatus = 50;
            hdr.Account = rowhdr["店铺名称"].ToString();
            hdr.ReceiverName = rowhdr["收货人姓名"].ToString();
            hdr.TrackingNo = rowhdr["物流单号 "].ToString().Replace("No:", "");
            hdr.CreditCardFee = 1;
            hdr.AlipayAccount = rowhdr["买家支付宝账号"].ToString();
            hdr.Type = "";
            hdr.TradeFrom = rowhdr["是否手机订单"].ToString();
            hdr.Flag = "";
            hdr.ReceiverTown = "";
            hdr.PicPath = "";
            return hdr;
        }
        private TbOrderDtl ConverRowToDtl(DataRow rowdtl, TbOrderHdr hdr)
        {


            #region hdr赋值
            TbOrderDtl dtl = new TbOrderDtl();
            dtl.Delete = false;
            dtl.SKU = rowdtl["商家编码"].ToString();
            dtl.Qty = int.Parse(rowdtl["购买数量"].ToString());
            dtl.Leave = dtl.Qty;
            dtl.Cost = 0;
            dtl.Price = (decimal)hdr.Payment;
            dtl.Uid = 2;
            dtl.Sn = "";
            dtl.CreateTime = DateTime.Now;
            dtl.OriginalPrice = decimal.Parse(rowdtl["价格"].ToString());
            IProductRepository dtlPro = dbSession.ProductRepository;

            var pro = dtlPro.LoadEntities(p => p.SKU == dtl.SKU).FirstOrDefault();

            if (pro == null)
                dtl.PicPath = "";
            else
                dtl.PicPath = pro.MainImage;


            dtl.Title = rowdtl["标题"].ToString();
            return dtl;
            #endregion
        }

        private string ConverStatus(string status)
        {
            switch (status)
            {
                case "买家已付款，等待卖家发货":
                    return "WAIT_SELLER_SEND_GOODS";
                case "卖家已发货，等待买家确认":
                    return "WAIT_BUYER_CONFIRM_GOODS";
                default:
                    return status;
            }
        }


        /// <summary>
        /// 订单出库
        /// </summary>
        /// <param name="billDtl"></param>
        public bool OutStock(List<TbOrderDtl> billDtl)
        {
            Result = "";

            ITbOrderDtlRepository dalDtl = new TbOrderDtlRepository();
            IBillDeliveryDtlRepository dalDelDtl = new BillDeliveryDtlRepository();
            IBillDeliveryHdrRepository dalDelHdr = new BillDeliveryHdrRepository();

            IBillGoodsReceiptDtlRepository dalGrDtl = new BillGoodsReceiptDtlRepository();
            var liSku = billDtl.Select(l => l.SKU).ToList();
            var grSku = dalGrDtl.LoadEntities(g => liSku.Contains(g.Code) && g.Leave > 0).OrderBy(u => u.Sn);//先进先出

            var groupSku = grSku.GroupBy(g => g.Code).Select(g => new
            {
                Sku = g.Key,
                Leave = g.Sum(u => u.Leave)
            });


            BillDeliveryHdr dhdr = new BillDeliveryHdr();

            dhdr.CheckDate = DateTime.Now;
            dhdr.Checker = 2;
            dhdr.CheckState = "已审核";
            dhdr.CreateTime = DateTime.Now;
            dhdr.Uid = 2;
            dhdr.SupplierID = "";
            dhdr.State = 0;
            dhdr.WHID = "GZ";
            dhdr.Freight = 0;
            dhdr.Formno = dalDelHdr.GetFormno();
            dhdr.Active = false;
            dhdr.Deleted = false;
            dhdr.Department = "";
            dhdr.Description = "";
            dhdr.ProductManager = "";



            foreach (TbOrderDtl dtl in billDtl)
            {
                var _rStock = groupSku.Where(s => s.Sku == dtl.SKU && s.Leave >= dtl.Leave).ToList();
                if (_rStock.Count == 0)
                {
                    Result += "SKU:" + dtl.SKU + "库存不足。</br>";
                    return false;
                }


                dhdr.PFormno = dtl.Formno;
                dalDelHdr.AddEntity(dhdr);

                var grDtls = grSku.Where(u => u.Code == dtl.SKU).ToList();

                //减去库存剩余量
                foreach (BillGoodsReceiptDtl gr in grDtls)
                {
                    BillDeliveryDtl ddtl = new BillDeliveryDtl();
                    ddtl.OrderFormno = dtl.Formno;
                    ddtl.OrderDtlID = dtl.ID;
                    ddtl.Sn = GetSn();
                    ddtl.WHID = "GZ";
                    ddtl.Uid = "2";
                    ddtl.Active = true;
                    ddtl.Tag = null;
                    ddtl.Price = gr.Price;
                    ddtl.ParentSn = gr.Sn;
                    ddtl.CreateTime = DateTime.Now;
                    ddtl.Code = gr.Code;
                    ddtl.Freeze = 0;
                    ddtl.Formno = dhdr.Formno;
                    ddtl.Deleted = false;
                    ddtl.RackNo = "";

                    //减订单剩余量
                    if (gr.Leave >= dtl.Leave)
                    {
                        ddtl.Leave = dtl.Leave;
                        ddtl.Qty = dtl.Leave;
                        gr.Leave -= dtl.Leave;
                        dtl.Leave = 0;
                    }
                    else
                    {
                        ddtl.Leave = gr.Leave;
                        ddtl.Qty = gr.Leave;
                        dtl.Leave -= gr.Leave;
                        gr.Leave = 0;
                    }



                    dalDelDtl.AddEntity(ddtl);
                    dalGrDtl.UpdateEntity(gr);

                    if (dtl.Leave == 0)
                        break;
                }
                dalDtl.UpdateEntity(dtl);

                try
                {
                    bool _r = dbSession.SaveChanges() > 0;
                    if (_r)
                    {
                        Result += "发货成功。";
                    }
                    return _r;
                }
                catch (Exception)
                {
                    throw;
                }

                //生成发货记录（也就是发货出库记录）
            }
            Result += "发货失败。";
            return false;
        }


        public DataTable EntityConverTable(List<TbOrderHdr> hdrs)
        {
            DataTable dt = new DataTable("主表");
            dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dt.Columns.Add("OrderId", Type.GetType("System.String"));
            dt.Columns.Add("BuyerNick", Type.GetType("System.String"));
            dt.Columns.Add("Uid", Type.GetType("System.Int32"));
            dt.Columns.Add("Payment", Type.GetType("System.Decimal"));
            dt.Columns.Add("ReceiverState", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverCity", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverDistrict", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverAddress", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverZip", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverMobile", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverPhone", Type.GetType("System.String"));
            dt.Columns.Add("CreateTime", Type.GetType("System.DateTime"));
            dt.Columns.Add("Delete", Type.GetType("System.Boolean"));
            dt.Columns.Add("PayTime", Type.GetType("System.DateTime"));
            dt.Columns.Add("Status", Type.GetType("System.String"));
            dt.Columns.Add("Formno", Type.GetType("System.String"));
            dt.Columns.Add("TotalPrice", Type.GetType("System.Decimal"));
            dt.Columns.Add("ShippingFee", Type.GetType("System.Decimal"));
            dt.Columns.Add("OrderStatus", Type.GetType("System.Int32"));
            dt.Columns.Add("Account", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverName", Type.GetType("System.String"));
            dt.Columns.Add("TrackingNo", Type.GetType("System.String"));
            dt.Columns.Add("CreditCardFee", Type.GetType("System.Decimal"));
            dt.Columns.Add("AlipayAccount", Type.GetType("System.String"));
            dt.Columns.Add("Type", Type.GetType("System.String"));
            dt.Columns.Add("TradeFrom", Type.GetType("System.String"));
            dt.Columns.Add("Flag", Type.GetType("System.String"));
            dt.Columns.Add("ReceiverTown", Type.GetType("System.String"));
            dt.Columns.Add("PicPath", Type.GetType("System.String"));
            dt.Columns.Add("TutorialPic", Type.GetType("System.String"));
            foreach (var hdr in hdrs)
            {
                DataRow row = dt.NewRow();
                row["ID"] = hdr.ID;
                row["OrderId"] = hdr.OrderId;
                row["BuyerNick"] = hdr.BuyerNick;
                row["Uid"] = hdr.Uid;
                row["Payment"] = hdr.Payment;
                row["ReceiverState"] = hdr.ReceiverState;
                row["ReceiverCity"] = hdr.ReceiverCity;
                row["ReceiverDistrict"] = hdr.ReceiverDistrict;
                row["ReceiverAddress"] = hdr.ReceiverAddress;
                row["ReceiverZip"] = hdr.ReceiverZip;
                row["ReceiverMobile"] = hdr.ReceiverMobile;
                row["ReceiverPhone"] = hdr.ReceiverPhone;
                row["CreateTime"] = hdr.CreateTime;
                row["Delete"] = hdr.Delete;
                row["PayTime"] = hdr.PayTime;
                row["Status"] = hdr.Status;
                row["Formno"] = hdr.Formno;
                row["TotalPrice"] = hdr.TotalPrice;
                row["ShippingFee"] = hdr.ShippingFee;
                row["OrderStatus"] = hdr.OrderStatus;
                row["Account"] = hdr.Account;
                row["ReceiverName"] = hdr.ReceiverName;
                row["TrackingNo"] = hdr.TrackingNo;
                row["CreditCardFee"] = hdr.CreditCardFee;
                row["AlipayAccount"] = hdr.AlipayAccount;
                row["Type"] = hdr.Type;
                row["TradeFrom"] = hdr.TradeFrom;
                row["Flag"] = hdr.Flag;
                row["ReceiverTown"] = hdr.ReceiverTown;
                row["PicPath"] = System.Configuration.ConfigurationManager.AppSettings["url"] + "/Images/FxptHelper.jpg";
                row["TutorialPic"] = System.Configuration.ConfigurationManager.AppSettings["url"] + "/Images/FxptHelper.jpg";
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
