using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.DAL.Info
{
    public partial class ProductHdrRepository : BaseRepository<ProductHdr>, IProductHdrRepository
    {
       
        public ProductHdrRepository()
        {
            base.TableName = "ProductHdr";
            Prefix = "";

        }
        //public string Save(ProductHdr hdr)
        //{
        //    DbSessionFactory dbf = new DbSessionFactory();
        //    IDbSession dbs = dbf.GetCurrentSession();
        //    var data = GetSequence(Prefix);
        //    hdr.SKU = Prefix + DateTime.Now.ToString("yy") + data.id.ToString().PadLeft(8, '0');
        //    hdr.CreateTime = Convert.ToDateTime(data.dt.ToString());
        //    AddEntity(hdr);
        //    bool _r = dbs.SaveChanges() > 0;
        //    if (_r)
        //    {
        //        return hdr.SKU;
        //    }
        //    return "";
        //} 
    }
}
