using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.Model.Info
{
    public enum TbStatus
    {
        未付款 = 0,
        等待发货=50,
        已发货=100,
        退款=110,
        需要评价=120,
        成功订单=130,
        关闭订单=140 
    }
}
