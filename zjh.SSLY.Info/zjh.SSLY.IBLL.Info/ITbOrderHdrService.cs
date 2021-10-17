using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.IBLL.Info
{
    public partial interface ITbOrderHdrService : IBaseService<TbOrderHdr>
    {
        bool Save(TbOrderHdr hdr, List<TbOrderDtl> dtls);
        void Save(DataTable hdrs, DataTable dtls);

        string Result { get; set; }
        /// <summary>
        /// 出库
        /// </summary>
        /// <param name="billDtl"></param>
        /// <returns></returns>
        bool OutStock(List<TbOrderDtl> billDtl);

        DataTable EntityConverTable(List<TbOrderHdr> hdrs);
    }
}
