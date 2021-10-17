using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.Model.Info
{
    public class SearchStockView
    {
        public int Leave { get; set; }
        public int Qty { get; set; }
        public string Title { get; set; }
        public string SKU { get; set; }

        /// <summary>
        /// 款式
        /// </summary>
        public string ManufacturerCode { get; set; } 
    }
}
