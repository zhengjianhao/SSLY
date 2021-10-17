using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.BLL.Info
{
    public class ModelProduct
    {
        public ModelProduct(int sku, string CreateUser, DateTime CreateTime, string ProImages, string Name,
            double Cost, string Source, string Category, string Remark, string States)
        {
            this.SKU = sku;
            this.CreateUser = CreateUser;
            this.CreateTime = CreateTime;
            this.ProImages = ProImages;
            this.Name = Name;
            this.Cost = Cost;
            this.Source = Source;
            this.Category = Category;
            this.Remark = Remark;
            this.States = States;
        }

        public int SKU { get; set; }
        public string CreateUser { get; set; }
        public DateTime CreateTime { get; set; }
        public string ProImages { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string Source { get; set; }
        public string Category { get; set; }
        public string Remark { get; set; }
        public string States { get; set; }

    }
}
