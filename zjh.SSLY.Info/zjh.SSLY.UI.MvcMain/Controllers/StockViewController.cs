using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class StockViewController : Controller
    {

        IStockViewService bll = new StockViewService();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadView()
        {
            var pageSize = int.Parse(Request["rows"] ?? "30");
            var pageIndex = int.Parse(Request["page"] ?? "1");
            int totalCount = 0;
            var tmp = bll.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.Code, false);

            var codes = tmp.Select(u => u.Code);
            IProductService bllPro = new ProductService();
            var liPro = bllPro.LoadEntities(p => codes.Contains(p.SKU));


            var stock = tmp.Join(liPro, s => s.Code, p => p.SKU, (s, p) => new
            {
                ID = p.ID,
                Qty = s.Qty ?? 0,
                Leave = s.Leave ?? 0,
                Title = p.Title ?? "",
                Price = p.Cost ?? 0,
                Cost = p.Cost ?? 0,
                SKU = p.SKU ?? "",
                CodeNum = p.CodeNum ?? "",
                Color = p.Color ?? "",
                MainImage = p.MainImage ?? "",
                ManufacturerCode = p.ManufacturerCode ?? ""
            });

            var rowStock = stock.OrderByDescending(u => u.ManufacturerCode).OrderByDescending(u => u.SKU).ToList();

            decimal? totalStock = 0;//总库存
            decimal? nowStock = 0;//现库存
            decimal totalCost = 0;//总成本
            decimal nowCost = 0;//剩余成本
            totalStock = tmp.Sum(u => u.Qty);
            nowStock = tmp.Sum(u => u.Leave);
            nowCost = stock.Sum(u => u.Cost * u.Leave);
            totalCost = stock.Sum(u => u.Cost * u.Qty);

            var data = new { total = totalCount, rows = rowStock, nowCost = (int)nowCost, totalCost = (int)totalCost, nowStock = (int)nowStock, totalStock = (int)totalStock };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //public object LoadData(SearchStockView search)
        //{
        //    var pageSize = int.Parse(Request["rows"] ?? "30");
        //    var pageIndex = int.Parse(Request["page"] ?? "1");
        //    int totalCount = 0;

        //    var tmp = bll.LoadPageEntities(u => u.ID > 0, pageIndex, pageSize, out totalCount, r => r.Code, false);
        //    if (!string.IsNullOrEmpty(search.SKU))
        //        tmp = tmp.Where(u => u.Code.Equals(search.SKU));

        //    var codes = tmp.Select(u => u.Code);
        //    IProductService bllPro = new ProductService();
        //    var liPro = bllPro.LoadEntities(p => codes.Contains(p.SKU));
            
        //    var stock = tmp.Join(liPro, s => s.Code, p => p.SKU, (s, p) => new
        //    {
        //        ID = p.ID,
        //        Qty = s.Qty ?? 0,
        //        Leave = s.Leave ?? 0,
        //        Title = p.Title ?? "",
        //        Price = p.Cost ?? 0,
        //        Cost = p.Cost ?? 0,
        //        SKU = p.SKU ?? "",
        //        CodeNum = p.CodeNum ?? "",
        //        Color = p.Color ?? "",
        //        MainImage = p.MainImage ?? "",
        //        ManufacturerCode = p.ManufacturerCode ?? ""
        //    });

        //    var rowStock = stock.OrderByDescending(u => u.ManufacturerCode).OrderByDescending(u => u.SKU).ToList();

        //    decimal? totalStock = 0;//总库存
        //    decimal? nowStock = 0;//现库存
        //    decimal totalCost = 0;//总成本
        //    decimal nowCost = 0;//剩余成本
        //    totalStock = tmp.Sum(u => u.Qty);
        //    nowStock = tmp.Sum(u => u.Leave);
        //    nowCost = stock.Sum(u => u.Cost * u.Leave);
        //    totalCost = stock.Sum(u => u.Cost * u.Qty);

        //    var data = new { total = totalCount, rows = rowStock, nowCost = (int)nowCost, totalCost = (int)totalCost, nowStock = (int)nowStock, totalStock = (int)totalStock };

        //    return null;
        //}

        public ActionResult LoadDtls()
        {

            return Content("");
        }
    }
}