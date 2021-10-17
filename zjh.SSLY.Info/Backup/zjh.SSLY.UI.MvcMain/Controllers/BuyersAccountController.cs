using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class BuyersAccountController : Controller
    {
        //
        //// GET: /BuyersAccount/

        //public IBLL.Info.IBuyersAccountService bll = new BLL.Info.BuyersAccountService();

        //public ActionResult Index()
        //{
        //    return View();
        //}

        //public ActionResult LoadBuyers()
        //{
        //    var pageSize = int.Parse(Request["rows"] ?? "10");
        //    var pageIndex = int.Parse(Request["page"] ?? "1");
        //    int totalCount = 0;
        //    var temp = bll.LoadPageEntities(u => true, pageIndex, pageSize, out totalCount, r => r.ID, false);
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    var data = new { total = totalCount, rows = temp };
        //    return Content(jss.Serialize(data));
        //}

        //public ActionResult Add()
        //{
        //    var TbAccount = Request["TbAccount"] ?? "";
        //    var TbPwd = Request["TbPassword"] ?? "";
        //    var ZfbAccount = Request["ZfbAccount"] ?? "";
        //    var Email = Request["Email"] ?? "";
        //    var Phone = Request["Phone"] ?? "";
        //    var Credit = Request["Credit"] ?? "0";
        //    var CreateTime = Request["CreateTime"] ?? "";
        //    var State = Request["State"] ?? "0";
        //    var Remark = Request["Remark"] ?? "";


        //    if (string.IsNullOrEmpty(TbAccount))
        //    {
        //        return Content("Error");
        //    }
        //    BuyersAccount model = new BuyersAccount()
        //    {
        //        TbAccount = TbAccount,
        //        TbPassword = TbPwd,
        //        ZfbAccount = ZfbAccount,
        //        Email = Email,
        //        Phone = Phone,
        //        Credit = int.Parse(Credit),
        //        CreateTime = DateTime.Now,
        //        State = int.Parse(State),
        //        Remark = Remark,
        //    };

        //    model = bll.AddEntity(model);
        //    if (model.ID > 0)
        //    {
        //        return Content("Ok");
        //    }
        //    return Content("Error");


        //}

        //public ActionResult Exit()
        //{
        //    var TbAccount = Request["TbAccount"] ?? "";
        //    var TbPassword = Request["TbPassword"] ?? "";
        //    var ZfbAccount = Request["ZfbAccount"] ?? "";
        //    var ZfbPassword = Request["ZfbPassword"] ?? "";
        //    var Email = Request["Email"] ?? "";
        //    var Phone = Request["Phone"] ?? "";
        //    var Credit = Request["Credit"] ?? "0";
        //    var CreateTime = Request["CreateTime"] ?? "";
        //    var State = Request["State"] ?? "0";
        //    var Remark = Request["Remark"] ?? "";
        //    var ID = int.Parse(Request["ID"] ?? "0");


        //    if (ID < 1)
        //    {
        //        return Content("Error");
        //    }
        //    var baList = bll.LoadEntities(u => u.ID == ID).ToList();
        //    BuyersAccount model;
        //    if (baList.Count > 0)
        //    {
        //        model = baList[0];
        //        baList[0].TbAccount = TbAccount;
        //        baList[0].TbPassword = TbPassword;
        //        baList[0].ZfbAccount = ZfbAccount;
        //        baList[0].ZfbPassword = ZfbPassword;
        //        baList[0].Email = Email;
        //        baList[0].Phone = Phone;
        //        baList[0].Credit = int.Parse(Credit);
        //        baList[0].State = int.Parse(State);
        //        baList[0].Remark = Remark;
        //        bool b = bll.UpdateEntity(baList[0]);
        //        if (b)
        //        {
        //            return Content("Ok");
        //        }
        //        return Content("Error");
        //    }

        //    return Content("Error");

        //}


        //public ActionResult Delete()
        //{
        //    var ids = Request["ids"] ?? "";

        //    List<string> idsArr = ids.Trim(',').Split(',').ToList();
        //    foreach (var id in idsArr)
        //    {
        //        int _id = int.Parse(id);
        //        var ListModel = bll.LoadEntities(u => u.ID == _id).ToList();
        //        if (ListModel.Count > 0)
        //        {
        //            bll.DeleteEntity(ListModel[0]);
        //        }

        //    }
        //    return Content("Ok");
        //}
        //public ActionResult GetList()
        //{
        //    var ID = int.Parse(Request["ID"] ?? "0");
        //    var temp = bll.LoadEntities(u => u.ID == ID);
        //    JavaScriptSerializer jss = new JavaScriptSerializer();
        //    var data = new { total = 1, rows = temp };
        //    return Content(jss.Serialize(data));
        //}

    }
}
