using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.Model.Info
{
    public class ProductCategoryTree : ProductCategory
    {
        public string iconCls;
        public List<ProductCategoryTree> children;
        public string state;
        public bool checkeds = false; 
    }
}
