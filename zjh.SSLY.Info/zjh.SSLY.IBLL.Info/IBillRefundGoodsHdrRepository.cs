using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.IBLL.Info
{ 
    public partial interface IBillRefundGoodsHdrService : IBaseService<zjh.SSLY.Model.Info.BillRefundGoodsHdr>
    {
        bool Save(BillRefundGoodsHdr hdr, List<BillRefundGoodsDtl> dtls);
    }
}
