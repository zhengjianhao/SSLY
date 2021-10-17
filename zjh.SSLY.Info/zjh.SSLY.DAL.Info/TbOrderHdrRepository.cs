using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.DAL.Info
{
    public partial class TbOrderHdrRepository : BaseRepository<TbOrderHdr>, ITbOrderHdrRepository
    { 
        public TbOrderHdrRepository()
        {
            base.TableName = "TbOrderHdr";
            Prefix = "TB"; 
        } 
    }
}
