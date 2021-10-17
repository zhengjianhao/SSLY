using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.DAL.Info
{ 
    public partial class BillDeliveryHdrRepository : BaseRepository<BillDeliveryHdr>, IBillDeliveryHdrRepository
    {
 
        public BillDeliveryHdrRepository()
        {
            base.TableName = "BillDeliveryHdr";
            Prefix = "DEL"; 
        }
    }
}
