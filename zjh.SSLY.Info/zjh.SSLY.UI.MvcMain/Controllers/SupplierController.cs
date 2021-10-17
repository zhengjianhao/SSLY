using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
        IBLL.Info.ISupplierService bll = new BLL.Info.SupplierService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Save(Supplier model)
        {
            if (model.ID == 0)
            {
                model.CreateTime = DateTime.Now;
                bool _b = bll.LoadEntities(u => u.Url == model.Url).ToList().Count > 0;
                if (_b)
                {
                    return Content("Error");
                }
                bll.AddEntity(model);
            }
            var _Rm = bll.LoadEntities(u => u.ID == model.ID).ToList();
            if (_Rm.Count > 0)
            {
                _Rm[0].Company = model.Company;
                _Rm[0].Linkman = model.Linkman;
                _Rm[0].Phone = model.Phone;
                _Rm[0].Remark = model.Remark;
                _Rm[0].Url = model.Url;
                bll.UpdateEntity(_Rm[0]);
            }
            return Content("Ok");
        }

        public ActionResult LoadView()
        {
            var supplierlist = bll.LoadEntities(u => !u.Delete).OrderByDescending(u => u.CreateTime).ToList();
            if (supplierlist.Count > 0)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var data = new { total = supplierlist.Count, rows = supplierlist };
                return Content(jss.Serialize(data));
            }
            return Content("Error");
        }

        public ActionResult LoadCombo()
        {
            var supplierlist = bll.LoadEntities(u => !u.Delete).OrderByDescending(u => u.CreateTime).ToList();
            var comboxList = supplierlist.Select(u => new { text = u.Company, value = u.ID }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer(); 
            return Content(jss.Serialize(comboxList));
        }


        public ActionResult CreateProduct(string ids)
        {
            //List<int> idsList = new List<int>();
            //foreach (var item in ids.Trim(',').Split(','))
            //{
            //    idsList.Add(int.Parse(item));
            //}

            //List<Supplier> models = bll.LoadEntities(u => idsList.Contains(u.ID)).ToList();
            //IProductService bllpro = new ProductService();


            //foreach (Supplier model in models)
            //{
            //    var data = HttpWebResponseUtility.GetExecute(model.Url, null, "", null);
            //    string ZImage = string.Empty;//主图
            //    Regex reg = new Regex("preview\":\".+?.jpg");
            //    ZImage = reg.Match(data).Value.Replace("preview\":\"", "");


            //    reg = new Regex("skuMap.+?}}");
            //    string jsonStr = reg.Match(data).Value.Replace("skuMap\":{", "");
            //    reg = new Regex("\".+?}");

            //    ProductHdr hdr = new ProductHdr();
            //    hdr.SupplierID = model.ID;
            //    hdr.Title = model.Remark;
            //    hdr.Uid = CurUid;
            //    hdr.SKU = "";
            //    hdr.ZImage = ZImage;
            //    hdr.ManufacturerCode = model.Company;
            //    hdr.CreateTime = DateTime.Now;
            //    hdr = bllpro.AddEntity(hdr);
            //    hdr = bllpro.CreateSku(hdr);
            //    foreach (Match match in reg.Matches(jsonStr))
            //    {
            //        reg = new Regex("{.+?}");
            //        string strSxs = reg.Match(match.Value).Value;
            //        System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //        Temporary tem = jss.Deserialize<Temporary>(strSxs);
            //        if (tem != null)
            //        {
            //            string strTem = reg.Match(jsonStr).Value;
            //            ProductDtl dtl = new ProductDtl();
            //            dtl.CreateTime = DateTime.Now;
            //            dtl.Cost = tem.price;
            //            //dtl.Color
            //            dtl.Uid = CurUid;
            //            dtl.GxQty = tem.canBookCount;
            //            dtl.SKU = hdr.SKU;

            //            reg = new Regex(".+?:{");
            //            string[] sx = reg.Match(match.Value).Value.Replace(":{", "").Replace("\"", "").Replace("&gt", "").Split(';');
            //            dtl.Color = sx[0];
            //            dtl.CodeNum = sx[1];
            //            blldtl.AddEntity(dtl);
            //        }
            //    }
            //}
            return Content("Ok");
        }

        public ActionResult Delete(string ids)
        {
            List<int> idsList = new List<int>();
            foreach (var id in ids.Trim(',').Split(','))
            {
                idsList.Add(int.Parse(id));
            }
            List<Supplier> supList = bll.LoadEntities(u => idsList.Contains(u.ID)).ToList();
            foreach (var sup in supList)
            {
                sup.Delete = true;
                bll.UpdateEntity(sup);
            }
            return Content("Ok");
        }
    }
}
