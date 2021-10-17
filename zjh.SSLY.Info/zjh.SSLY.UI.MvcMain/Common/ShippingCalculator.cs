using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Common
{
    public class ShippingCalculator
    {
        /// <summary>
        /// 执行运算
        /// </summary>
        /// <returns></returns>
        public decimal PerformsArithmetic(int shippingID, decimal weight, string country)
        {
            IShippingService bll = new ShippingService();
            Shipping shipping = bll.LoadEntities(u => u.ID == shippingID).FirstOrDefault();
            if (shipping == null)
                return 0; 
            return 0;
        }
    }
}
