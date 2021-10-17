using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.DAL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    //public partial class ProductHdrService : BaseService<ProductHdr>, IProductHdrService
    //{
    //    private IProductHdrRepository dal = new ProductHdrRepository();
    //    public bool Save(ProductHdr hdr, List<ProductDtl> dtls)
    //    {
    //        IProductDtlRepository dalDtl = new ProductDtlRepository();
    //        string Sku = dal.Save(hdr);
    //        foreach (ProductDtl dtl in dtls)
    //        {
    //            dtl.SKU = Sku;
    //            dalDtl.AddEntity(dtl);
    //        }

    //        return dbSession.SaveChanges() > 0;

    //    } 
    //}
}
