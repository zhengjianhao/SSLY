using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class ProductController : Controller
    {
        public IBLL.Info.IProductService bll = new ProductService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id, bool copy)
        {
            Product item = new Product();
            if (id == 0)
            {
                item.ID = id;
                item.SKU = "0";
            }
            else
            {
                List<Product> pros = bll.LoadEntities(u => u.ID == id).ToList();
                if (copy)
                {

                    item = new Product();
                    item.GxQty = pros[0].GxQty;
                    item.GrossWeight = pros[0].GrossWeight;
                    item.Cost = pros[0].Cost;
                    item.AgeBracket = pros[0].AgeBracket;
                    item.AttributeID = pros[0].AttributeID;
                    item.CodeNum = pros[0].CodeNum;
                    item.Color = pros[0].Color;
                    item.Brand = pros[0].Brand;
                    item.State = pros[0].State;
                    item.Source = pros[0].Source;
                    item.SupplierID = pros[0].SupplierID;
                    item.CategoryID = pros[0].CategoryID;
                    item.NetWeight = pros[0].NetWeight;
                    item.ShippingFee = pros[0].ShippingFee;
                    item.Title = pros[0].Title;
                    item.ManufacturerCode = pros[0].ManufacturerCode;
                    item.Remark = pros[0].Remark;
                    item.Keywords = pros[0].Keywords;
                    item.USDes = pros[0].USDes;
                    item.CHNDes = pros[0].CHNDes;
                    item.SalePrice = pros[0].SalePrice;
                }
                else
                {
                    item = pros[0];
                }
            }
            ViewBag.Model = item;
            return View();
        }

        #region crud
        public ActionResult LoadView()
        {
            DateTime sTime, eTime;
            if (string.IsNullOrEmpty(Request["starkTime"]))
            {
                sTime = Convert.ToDateTime("2014-01-01");
            }
            else
            {
                sTime = Convert.ToDateTime(Request["starkTime"]);
            }
            if (string.IsNullOrEmpty(Request["endTime"]))
            {
                eTime = DateTime.Now;
            }
            else
            {
                eTime = Convert.ToDateTime(Request["endTime"]);
            }

            string[] categorys = (Request["CategoryID"] ?? "").Split(',');
            List<int> cates = new List<int>();
            foreach (var cate in categorys)
            {
                if (!string.IsNullOrEmpty(cate))
                    cates.Add(int.Parse(cate));
            }

            string txtField = Request["Field"] ?? "";
            string txtvalue = Request["value"] ?? "";
            Expression<Func<Product, bool>> whereLambda = null;
            if (!string.IsNullOrEmpty(txtvalue))
            {
                switch (txtField)
                {
                    case "SKU":
                        whereLambda = u => cates.Contains(u.CategoryID) && !u.Delete && u.SKU.Contains(txtvalue) && u.CreateTime > sTime && u.CreateTime < eTime;
                        break;
                    case "Title":
                        whereLambda = u => cates.Contains(u.CategoryID) && !u.Delete && u.Title.Contains(txtvalue) && u.CreateTime > sTime && u.CreateTime < eTime; ;
                        break;
                    case "SupplierID":
                        whereLambda = u => cates.Contains(u.CategoryID) && !u.Delete && u.SupplierID.Equals(txtvalue) && u.CreateTime > sTime && u.CreateTime < eTime; ;
                        break;
                    case "Uid":
                        whereLambda = u => cates.Contains(u.CategoryID) && !u.Delete && u.Uid.Equals(txtvalue) && u.CreateTime > sTime && u.CreateTime < eTime; ;
                        break;
                    case "Remark":
                        whereLambda = u => cates.Contains(u.CategoryID) && !u.Delete && (u.Remark.IndexOf(txtvalue) > 0) && u.CreateTime > sTime && u.CreateTime < eTime; ;
                        break;
                }
            }
            else
            {
                if (cates.Count == 0)
                {
                    whereLambda = u => !u.Delete && u.CreateTime > sTime && u.CreateTime < eTime; ;
                }
                else
                {
                    whereLambda = u => cates.Contains(u.CategoryID) && !u.Delete && u.CreateTime > sTime && u.CreateTime < eTime; ;
                }

            }
            var pageSize = int.Parse(Request["rows"] ?? "30");
            int page = int.Parse(Request["page"] ?? "1");
            var pageIndex = page == 0 ? 1 : page;
            int totalCount = 0;

            SupplierService bllSup = new SupplierService();

            var proTemp = bll.LoadPageEntities(whereLambda, pageIndex, pageSize, out totalCount, u => u.ID, false).ToList();
            var tempIDs = proTemp.Select(u => u.SupplierID);
            var supTemp = bllSup.LoadEntities(u => tempIDs.Contains(u.ID));
            var temp = proTemp.Join(supTemp, hdr => hdr.SupplierID, sup => sup.ID, (hdr, sup) => new
            {
                hdr.ID,
                hdr.MainImage,
                hdr.Uid,
                hdr.Title,
                hdr.State,
                SupUrl = sup.Url,
                hdr.Remark,
                hdr.SKU,
                hdr.CreateTime,
                hdr.SupplierID,
                hdr.ShippingFee,
                hdr.Cost,
                hdr.SalePrice,
                hdr.ManufacturerCode,
                hdr.Color,
                hdr.CodeNum,
                hdr.GrossWeight,
                hdr.NetWeight
            }).OrderByDescending(u => u.ManufacturerCode).OrderByDescending(u => u.CreateTime).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var data = new { total = totalCount, rows = temp };
            return Content(jss.Serialize(data));
        }

        [HttpPost]
        public ActionResult Save(Product Model)
        {
            string message = string.Empty;
            if (Model.ID > 0)
            {
                var proItems = bll.LoadEntities(u => u.ID == Model.ID).ToList();
                if (proItems.Count > 0)
                {
                    proItems[0].Remark = Model.Remark ?? "";
                    proItems[0].SalePrice = Model.SalePrice ?? 0;
                    proItems[0].ShippingFee = Model.ShippingFee ?? 0;
                    proItems[0].SupplierID = Model.SupplierID;
                    proItems[0].Cost = Model.Cost ?? 0;
                    proItems[0].Title = Model.Title ?? "";
                    proItems[0].NetWeight = Model.NetWeight ?? 0;
                    proItems[0].GrossWeight = Model.GrossWeight ?? 0;
                    proItems[0].GxQty = Model.GxQty ?? 0;
                    proItems[0].Color = Model.Color ?? "";
                    proItems[0].CodeNum = Model.CodeNum ?? "";
                    proItems[0].AgeBracket = Model.AgeBracket ?? 0;
                    proItems[0].Brand = Model.Brand ?? "";
                    proItems[0].Source = Model.Source ?? "";
                    proItems[0].ManufacturerCode = Model.ManufacturerCode ?? "";
                    proItems[0].USDes = Model.USDes ?? "";
                    proItems[0].CHNDes = Model.CHNDes ?? "";
                    proItems[0].Keywords = Model.Keywords ?? "";
                    bool result = bll.UpdateEntity(proItems[0]);

                    if (result)
                    {
                        message = "Ok";
                    }
                    else
                    {
                        message = "更新失败！请稍后再试。";
                    }
                }
            }
            else
            {
                Model.Remark = Model.Remark ?? "";
                Model.SalePrice = Model.SalePrice ?? 0;
                Model.ShippingFee = Model.ShippingFee ?? 0;
                Model.SupplierID = Model.SupplierID;
                Model.CategoryID = Model.CategoryID;
                Model.Cost = Model.Cost ?? 0;
                Model.Title = Model.Title ?? "";
                Model.NetWeight = Model.NetWeight ?? 0;
                Model.GrossWeight = Model.GrossWeight ?? 0;
                Model.GxQty = Model.GxQty ?? 0;
                Model.Color = Model.Color ?? "";
                Model.CodeNum = Model.CodeNum ?? "";
                Model.AgeBracket = Model.AgeBracket ?? 0;
                Model.Brand = Model.Brand ?? "";
                Model.Source = Model.Source ?? "";
                Model.Uid = 2;
                Model.USDes = Model.USDes ?? "";
                Model.CHNDes = Model.CHNDes ?? "";
                Model.Keywords = Model.Keywords ?? "";
                bll.Save(Model);
                message = "Ok";
            }
            return Content(message);
        }
        #endregion


        #region 导出
        //public ActionResult ExportExcel()
        //{

        //}
        #endregion
        #region 相册
        public ActionResult PhotoAlbum()
        {
            return View();
        }

        /// <summary>
        /// 相片预览
        /// </summary>
        /// <returns></returns>
        public ActionResult PhotoPreview()
        {

            return View();
        }

        public ActionResult GetDocImages(string sku)
        {
            if (string.IsNullOrEmpty(sku))
                return Content("None");

            IDocumentService bllPhoto = new DocumentService();
            var liImage = bllPhoto.LoadEntities(u => u.Type == "Image" && u.SKU == sku).OrderByDescending(u => u.CreateTime).ToList();
            return Json(liImage, JsonRequestBehavior.AllowGet);
        }
        #endregion


    }
}
