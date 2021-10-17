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
    public partial class BillRefundGoodsHdrService : BaseService<BillRefundGoodsHdr>, IBillRefundGoodsHdrService
    {
        private IBillRefundGoodsHdrRepository dal = new BillRefundGoodsHdrRepository();
        public bool Save(BillRefundGoodsHdr hdr, List<BillRefundGoodsDtl> dtls)
        {
            IBillRefundGoodsDtlRepository dalDtl = new BillRefundGoodsDtlRepository();
            string formno = dal.Save(hdr);
            foreach (BillRefundGoodsDtl dtl in dtls)
            {
                dtl.Uid = "1";
                dtl.Formno = formno;
                dtl.Active = true;
                dtl.Sn = GetSn();
                dtl.Deleted = false;
                dtl.CreateTime = DateTime.Now;
                dtl.Leave = dtl.Qty;
                dtl.Tag = false;
                dtl.ParentSn = "/";
                dtl.Freeze = 0;
                dtl.WHID = hdr.WHID;
                dtl.RackNo = "";
                dalDtl.AddEntity(dtl);
            }
            return dbSession.SaveChanges() > 0;
        }

    }
}
