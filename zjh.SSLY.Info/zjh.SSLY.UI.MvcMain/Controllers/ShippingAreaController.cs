using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using zjh.SSLY.UI.MvcMain.Filters;
using zjh.SSLY.UI.MvcMain.Models;
using zjh.SSLY.Model.Info;
using System.Linq.Expressions;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    //[Authorize]
    //[InitializeSimpleMembership]
    public class ShippingAreaController : Controller
    {
        zjh.SSLY.IBLL.Info.IShippingAreaService bll = new BLL.Info.ShippingAreaService();

        public ActionResult Index()
        {
            return View();
        }

        #region crud 

        [HttpPost]
        public ActionResult Save(ShippingArea Model)
        {
            string message = string.Empty;
            if (Model.ID > 0)
            {
                var ShippingAreas = bll.LoadEntities(u => u.ID == Model.ID).ToList();
                if (ShippingAreas.Count > 0)
                {
                    ShippingAreas[0].AdditionalCost = Model.AdditionalCost ?? 0;
                    ShippingAreas[0].Area = Model.Area;
                    ShippingAreas[0].ContinuePrice = Model.ContinuePrice ?? 0;
                    ShippingAreas[0].ContinueWeight = Model.ContinueWeight ?? 0;
                    ShippingAreas[0].CountryGroup = Model.CountryGroup ?? "";

                    ShippingAreas[0].Discount = Model.Discount ?? 0;
                    ShippingAreas[0].FirstPrice = Model.FirstPrice ?? 0;
                    ShippingAreas[0].FirstWeight = Model.FirstWeight ?? 0;
                    ShippingAreas[0].FuelCost = Model.FuelCost ?? 0;
                    ShippingAreas[0].EndWeight = Model.EndWeight ?? 0;
                    ShippingAreas[0].IntervalPirce = Model.IntervalPirce ?? 0;
                    //
                    //
                    bool result = bll.UpdateEntity(ShippingAreas[0]);
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
                Model.CreateTime = DateTime.Now;
                Model.Uid = 0;
                Model.AdditionalCost = Model.AdditionalCost ?? 0;
                Model.Area = Model.Area;
                Model.ContinuePrice = Model.ContinuePrice ?? 0;
                Model.ContinueWeight = Model.ContinueWeight ?? 0;
                Model.Discount = Model.Discount ?? 0;
                Model.FirstPrice = Model.FirstPrice ?? 0;
                Model.FirstWeight = Model.FirstWeight ?? 0;
                Model.FuelCost = Model.FuelCost ?? 0;
                //                ID, Area, ShippingID, FirstWeight,
                // ContinueWeight, FirstPrice, ContinuePrice, 
                //AdditionalCost, FuelCost, Shipping_ID, Discount, Uid, CreateTime
                var result = bll.AddEntity(Model);
                if (result.ID > 0)
                {
                    message = "Ok";
                }
                else
                {
                    message = "添加失败！请稍后再试。";
                }

            }
            return Content(message);
        }
        //加载视图 
        public ActionResult LoadView()
        {
            var pageSize = int.Parse(Request["rows"] ?? "30");
            int pageIndex = 1;
            int.TryParse(Request["page"], out pageIndex);
            pageIndex = pageIndex == 0 ? 1 : pageIndex;


            int totalCount = 0;
            string txtField = Request["Field"] ?? "";
            string txtvalue = Request["value"] ?? "";
            Expression<Func<ShippingArea, bool>> whereLambda = null;

            if (!string.IsNullOrEmpty(txtvalue))
            {
                switch (txtField)
                {
                    case "ID":
                        int ID = int.Parse(txtvalue);
                        whereLambda = u => u.ID == ID;
                        break;
                }
            }
            else
            {
                whereLambda = u => u.ID > 0;
            }

            List<ShippingArea> tmpShippingArea = bll.LoadPageEntities(whereLambda, pageIndex, pageSize, out totalCount, r => r.CreateTime, false).ToList();
            var tmp = tmpShippingArea.Select(u => new
            {
                Area = u.Area,
                FirstWeight = u.FirstWeight,
                ContinueWeight = u.ContinueWeight,
                FirstPrice = ((decimal)u.FirstPrice).ToString("0.00"),
                ContinuePrice = ((decimal)u.ContinuePrice).ToString("0.00"),
                AdditionalCost = ((decimal)u.AdditionalCost).ToString("0.00"),
                FuelCost = ((decimal)u.FuelCost).ToString("0.00"),
                Discount = ((decimal)u.Discount).ToString("0.0000"),
                Uid = u.Uid,
                CreateTime = u.CreateTime,
                ShippingName = u.Shipping.ShippingName,
                EndWeight = u.EndWeight,
                IntervalPirce = ((decimal)u.IntervalPirce).ToString("0.00"),
                Shipping_ID = u.Shipping_ID,
                CountryGroup = u.CountryGroup,
                Price=u.Price,
                Weight=u.Weight,
                ID = u.ID
            }).OrderBy(u => u.Shipping_ID).OrderByDescending(u => u.ID).ToList();


            var data = new { total = totalCount, rows = tmp };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion


        public ActionResult ImportShippingExecl(string view)
        {
            return View();
        }

        public ActionResult ImportShippingExeclFile()
        {
            HttpPostedFileBase Filedata = Request.Files["filedata"];
            int shipping_ID = int.Parse(Request["Shipping_ID"]);
            int shippingType = int.Parse(Request["shippingType"]);
            
            IShippingSheet sheet = ShippingStorage.CreateSheet();

            ResponseData rd = new ResponseData();
            rd.IsSuccess = sheet.ImportShippingArea(Filedata.InputStream, shipping_ID, shippingType);
            rd.CallTime = DateTime.Now.ToString("yyyy-MMy-dd hh:mm:ss");
            return Json(rd);
        }
    }
}
