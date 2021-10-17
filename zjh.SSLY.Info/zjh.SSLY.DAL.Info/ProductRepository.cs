using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.DAL.Info
{
    public partial class ProductRepository : BaseRepository<Product>, IProductRepository
    {
     
        public ProductRepository()
        {
            base.TableName = "Product";
            Prefix = "PRO";

        }

        public string Save(Product proItem, string CategoryCode)
        {
            DbSessionFactory dbf = new DbSessionFactory();
            IDbSession dbs = dbf.GetCurrentSession();
            var data = GetSequence(CategoryCode);
            proItem.SKU = CategoryCode + data.id.ToString().PadLeft(5, '0');
            proItem.CreateTime = Convert.ToDateTime(data.dt.ToString());
            AddEntity(proItem);
            bool _r = dbs.SaveChanges() > 0;
            if (_r)
            {
                return proItem.SKU;
            }
            return "";
        }
    }
}
