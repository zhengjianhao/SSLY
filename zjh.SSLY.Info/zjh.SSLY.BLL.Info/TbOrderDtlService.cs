using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    public partial class TbOrderDtlService : BaseService<TbOrderDtl>, ITbOrderDtlService
    {
        public DataTable EntityConverTable(List<TbOrderDtl> dtls)
        {
            var liSku = dtls.Select(u => u.SKU).ToList();
            IProductRepository dtlPro = dbSession.ProductRepository;
            var products = dtlPro.LoadEntities(p => liSku.Contains(p.SKU)).ToList();
             

            DataTable dt = new DataTable("明细");
            dt.Columns.Add("ID", Type.GetType("System.Int32"));
            dt.Columns.Add("Formno", Type.GetType("System.String"));
            dt.Columns.Add("SKU", Type.GetType("System.String"));
            dt.Columns.Add("Qty", Type.GetType("System.Int32"));
            dt.Columns.Add("Cost", Type.GetType("System.Decimal"));
            dt.Columns.Add("Price", Type.GetType("System.Int32"));
            dt.Columns.Add("Uid", Type.GetType("System.Int32"));
            dt.Columns.Add("Sn", Type.GetType("System.String"));
            dt.Columns.Add("Delete", Type.GetType("System.Boolean"));
            dt.Columns.Add("CreateTime", Type.GetType("System.DateTime"));
            dt.Columns.Add("PicPath", Type.GetType("System.String"));
            dt.Columns.Add("Titile", Type.GetType("System.String"));
            dt.Columns.Add("SkuPropertiesName", Type.GetType("System.String"));
            dt.Columns.Add("OriginalPrice", Type.GetType("System.String"));
            foreach (var dtl in dtls)
            {
                DataRow row = dt.NewRow();
                row["ID"] = dtl.ID;
                row["Formno"] = dtl.Formno;
                row["SKU"] = dtl.SKU;
                row["Qty"] = dtl.Qty;
                row["Cost"] = dtl.Cost;
                row["Price"] = dtl.Price;
                row["Uid"] = dtl.Uid;
                row["Sn"] = dtl.Sn;
                row["Delete"] = dtl.Delete;
                row["CreateTime"] = dtl.CreateTime; 
                row["Titile"] = dtl.Title;
                row["SkuPropertiesName"] = "";
                var pro = products.Where(u => u.SKU == dtl.SKU).FirstOrDefault();
                if (pro != null)
                {
                    row["SkuPropertiesName"] = pro.Color;
                
                }

                row["PicPath"] = System.Configuration.ConfigurationManager.AppSettings["url"] + dtl.PicPath;
                row["OriginalPrice"] = dtl.OriginalPrice;
                dt.Rows.Add(row);
            }
            return dt;
        }
    }
}
