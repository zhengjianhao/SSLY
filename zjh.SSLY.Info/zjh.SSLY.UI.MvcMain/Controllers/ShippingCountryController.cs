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
using zjh.SSLY.BLL.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{ 
    public class ShippingCountryController : Controller
    {
        //GET: /BillPurchase/

        ShippingCountryService bll = new ShippingCountryService();
        /// <summary>
        /// 国家同步
        /// </summary>
        /// <returns></returns>
        public ActionResult Synchronous()
        {
            var listCountry = bll.LoadEntities(u => u.ID > 0).ToList();
            ShippingAreaService bllSA = new ShippingAreaService();
            var tempSA = bllSA.LoadEntities(u => u.IsComplete == false).ToList();

            foreach (var item in tempSA)
            {
                string[] countrygroup = item.CountryGroup.Split(',');
                bool isSuccess = false;
                string countryStr = string.Empty;
                foreach (var country in countrygroup)
                {
                    ShippingCountry sc = listCountry.Where(l => l.Chinese == country.Trim()).FirstOrDefault();
                    if (sc != null)
                    {
                        countryStr += sc.Coding + ",";
                    }
                    else
                    {
                        isSuccess = false;
                        countryStr += country + ",";
                    }
                }
                item.CountryGroup = countryStr.Trim(',');
                item.IsComplete = isSuccess;
                bllSA.UpdateEntity(item);
            }

            ResponseData rd = new ResponseData();
            rd.IsSuccess = true;
            rd.CallTime = DateTime.Now.ToString("yyyy-MMy-dd hh:mm:ss");
            return Json(rd);
        }
    }
}
