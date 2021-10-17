using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class ProductCategoryController : Controller
    {
        zjh.SSLY.IBLL.Info.IProductCategoryService bll = new BLL.Info.ProductCategoryService();
        //
        // GET: /ProductCategory/ 
        public ActionResult Index()
        {
            return View();
        }
         
        public ActionResult LoadTree(string combo)
        { 
            string result = string.Empty;
            List<ProductCategoryTree> TreeList = bll.GetCategoryTree();
            System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            if (combo == "combo")
            {
                List<ProductCategoryTree> Trees = new List<ProductCategoryTree>();
                ProductCategoryTree tree = new ProductCategoryTree()
                {
                    FID = 0,
                    Node = "全部",
                    ID = 0,
                    Sort = 1
                };

                tree.children = new List<ProductCategoryTree>();
                tree.children.AddRange(TreeList);
                Trees.Add(tree);
                result = jss.Serialize(Trees);
            }
            else
            {
                result = jss.Serialize(TreeList);
            }  
            result = result.Replace("ID", "id").Replace("Node", "text").Replace("checkeds", "checked");
            return Content(result);
        }
        public ActionResult Save(ProductCategory model)
        {
            if (model.ID == 0)
            {
                model.Uid = 2;
                model.CreateTime = DateTime.Now;
                model.Delete = false;
                model.Active = true;
                model = bll.AddEntity(model);
            }
            else
            {
                var pcs = bll.LoadEntities(u => u.ID == model.ID).ToList();
                if (pcs.Count > 0)
                {
                    ProductCategory pc = pcs[0];
                    pc.Node = model.Node;
                    bll.UpdateEntity(pc);
                }
            }
            int result = bll.SpEditCategoryLoc("ProductCategory", model.ID.ToString(), model.FID.ToString(), model.Sort.ToString());
            return Content("OK");
        }
    }
}
