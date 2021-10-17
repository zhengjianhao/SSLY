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
using System.Web.Script.Serialization;
using zjh.SSLY.BLL.Info;
using System.IO;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    //[Authorize]
    //[InitializeSimpleMembership]
    public class ShippingController : Controller
    {
        zjh.SSLY.IBLL.Info.IShippingService bll = new BLL.Info.ShippingService();

        public ActionResult Index()
        {
            return View();
        }

        #region crud 

        [HttpPost]
        public ActionResult Save(Shipping Model)
        {
            string message = string.Empty;
            if (Model.ID > 0)
            {
                var shippings = bll.LoadEntities(u => u.ID == Model.ID).ToList();
                if (shippings.Count > 0)
                {
                    shippings[0].ShippingName = Model.ShippingName ?? "";
                    shippings[0].ShippingUSName = Model.ShippingUSName ?? "";
                    shippings[0].CalculateFormula = Model.CalculateFormula ?? "";
                    shippings[0].AdditionalCost = Model.AdditionalCost ?? 0;
                    shippings[0].Discount = Model.Discount ?? 0;
                    shippings[0].FuelDiscount = Model.FuelDiscount ?? 0;
                    shippings[0].FuelCost = Model.FuelCost ?? 0;
                    bool result = bll.UpdateEntity(shippings[0]);
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
            var pageIndex = int.Parse(Request["page"] ?? "1");
            int totalCount = 0;


            string txtField = Request["Field"] ?? "";
            string txtvalue = Request["value"] ?? "";
            Expression<Func<Shipping, bool>> whereLambda = null;

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

            List<Shipping> tmpShipping = bll.LoadPageEntities(whereLambda, pageIndex, pageSize, out totalCount, r => r.CreateTime, false).ToList();
            var tmp = tmpShipping.Select(u => new
            {
                CalculateFormula = u.CalculateFormula,
                ShippingName = u.ShippingName,
                ShippingUSName = u.ShippingUSName,

                AdditionalCost = ((decimal)u.AdditionalCost).ToString("0.00"),
                Discount = ((decimal)u.Discount).ToString("0.0000"),
                FuelDiscount = ((decimal)u.FuelDiscount).ToString("0.0000"),
                FuelCost = ((decimal)u.FuelCost).ToString("0.00"),
                ID = u.ID
            }).ToList();

            var data = new { total = totalCount, rows = tmp };
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        #endregion

        public ActionResult LoadCombo()
        {
            var shippinglist = bll.LoadEntities(u => u.ID > 0).OrderBy(u => u.ShippingName).ToList();
            var comboxList = shippinglist.Select(u => new { text = u.ShippingName, value = u.ID }).ToList();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            return Content(jss.Serialize(comboxList));
        }



    }
}
