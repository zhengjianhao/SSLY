using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.BLL.Info
{
    public partial class ProductCategoryService : BaseService<ProductCategory>, IProductCategoryService
    {

        public List<ProductCategoryTree> CurrTree;
        public List<ProductCategoryTree> GetCategoryTree()
        {
            List<ProductCategoryTree> TreeList = new List<ProductCategoryTree>();
            TreeList = new List<ProductCategoryTree>();

            CurrTree = CurrentRepository.LoadEntities(u => u.Delete == false).Select(u => new ProductCategoryTree
            {
                Sort = u.Sort,
                Uid = u.Uid,
                FID = u.FID == null ? 0 : u.FID,
                ID = u.ID,
                Node = u.Node,
                Active = u.Active,
                CreateTime = u.CreateTime,
                Delete = u.Delete,
                Code = u.Code??""
            }).ToList();

            var data = CurrTree.Where(u => u.FID == 0).OrderBy(b => b.Sort);
            foreach (ProductCategoryTree tree in data)
            {
                FindChildNode(tree);
                TreeList.Add(tree);
            }
            return TreeList;
        }
        public void FindChildNode(ProductCategoryTree tree)
        {
            tree.children = new List<ProductCategoryTree>();
            var trees = CurrTree.Where(u => u.FID == tree.ID).OrderBy(b => b.Sort);

            foreach (ProductCategoryTree _tree in trees)
            {
                FindChildNode(_tree);
                tree.children.Add(_tree);
            }
        }


    }
}
