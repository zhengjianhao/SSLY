using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using zjh.SSLY.DAL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    public partial class ProductService : BaseService<Product>, IProductService
    {
        private IProductRepository dal = new ProductRepository();
        public bool Save(Product proItem)
        {
            IProductCategoryRepository dalproCategory = new ProductCategoryRepository();
            var temp = dalproCategory.LoadEntities(u => u.ID == proItem.CategoryID).ToList();
            if (temp.Count == 0)
                return false;
            string Sku = dal.Save(proItem, temp[0].Code);
            return true;
        }
    }
}
