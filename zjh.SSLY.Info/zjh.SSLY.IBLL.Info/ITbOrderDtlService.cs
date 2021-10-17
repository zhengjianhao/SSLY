using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.IBLL.Info
{
    public partial interface ITbOrderDtlService : IBaseService<TbOrderDtl>
    {
        DataTable EntityConverTable(List<TbOrderDtl> dtls);
    }
}
