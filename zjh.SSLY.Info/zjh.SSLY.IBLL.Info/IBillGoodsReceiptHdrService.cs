using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.IBLL.Info
{ 
    public partial interface IBillGoodsReceiptHdrService : IBaseService<zjh.SSLY.Model.Info.BillGoodsReceiptHdr>
    {
        bool Save(BillGoodsReceiptHdr hdr, List<BillGoodsReceiptDtl> dtls);
    }
}
