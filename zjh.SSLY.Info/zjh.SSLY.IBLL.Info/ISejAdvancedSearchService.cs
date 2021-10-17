using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.IBLL.Info
{
    public partial interface ISejAdvancedSearchService : IBaseService<SejAdvancedSearch>
    {
        DataTable ShowReportDt(DataTable dt);
        DataTable ShowReportDt(System.Data.DataTable dt, Dictionary<string, string> dicColumns);
    }
}
