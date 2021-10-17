using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;
using System.Text;
namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class FileResourceController : Controller
    {
        //
        // GET: /FileResource/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileIndex(string SKU)
        {
            ViewData["SKU"] = SKU;
            return View();
        }

        public ActionResult Delete(int ID)
        {
            IDocumentService bll = new DocumentService();
            List<Document> list = bll.LoadEntities(u => u.ID == ID).ToList();
            if (list.Count > 0)
            {
                bll.DeleteEntity(list[0]);
            }
            return Content("OK");
        }
        public ActionResult SetZImage(int ID,string SKU)
        {
            IProductService bll = new ProductService();
            List<Product> ProEntitys = bll.LoadEntities(u => u.SKU == SKU).ToList();
             

            if (ProEntitys.Count > 0)
            {
                DocumentService bllDoc = new DocumentService();
                var docList = bllDoc.LoadEntities(u => u.ID == ID).ToList();
                if (docList.Count > 0)
                {
                    ProEntitys[0].MainImage = docList[0].Path;
                    var result = bll.UpdateEntity(ProEntitys[0]);
                    if (result)
                    {
                        return Content("Ok");
                    }
                }
            }
            return Content("OK");
        }

     



        public ActionResult FileUp(string Code)
        {
            if (string.IsNullOrEmpty(Code))
                return Content(""); 
            HttpPostedFileBase Filedata = Request.Files["Filedata"];
            string filePath = Server.MapPath("/Data/ProductFile/Images/" + Code + "/");
            string CodeImage = Code + "/" + Filedata.FileName;
            if (!System.IO.Directory.Exists(filePath))
            {
                System.IO.Directory.CreateDirectory(filePath);
            }
            string _file = filePath + Filedata.FileName;
            Filedata.SaveAs(_file);
            IBLL.Info.IDocumentService bllDoc = new DocumentService();
            bool _r = bllDoc.LoadEntities(u => u.Path.Contains(CodeImage)).Count() > 0;
            if (_r)
            {
                return Content("Error");
            }
            else
            {
                Document doc = new Document();
                doc.SKU = Code;
                doc.Path = "/Data/ProductFile/Images/" + Code + "/" + Filedata.FileName;
                doc.CreateTime = DateTime.Now;
                doc.Uid = 0;
                doc.Type = "Image";
                bllDoc.AddEntity(doc);
            }
            return Content("Ok");
        }
    }
}
