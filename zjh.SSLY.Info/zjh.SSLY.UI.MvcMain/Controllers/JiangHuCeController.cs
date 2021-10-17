using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using zjh.SSLY.BLL.Info;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class JiangHuCeController : Controller
    {
        //
        // GET: /JiangHuCe/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LoadSummary()
        { 
            return View();
        }

        public ActionResult PvUvSummary(string pvuv, string SKU, string days, string clientType)
        {
            DateTime dtime = DateTime.Now;
            if (!string.IsNullOrEmpty(SKU) || !string.IsNullOrEmpty(days))
            {
                dtime = DateTime.Parse(days);
                PvuvService bll = new PvuvService();
                try
                {
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    var resulePvuv = jss.Deserialize<Pvuv>(pvuv);
                    foreach (Guide g in resulePvuv.res.guide)
                    {
                        var entitys = bll.LoadEntities(u => u.SKU == SKU && u.puTime == dtime && u.KeyWord == g.keyWord).ToList();
                        if (entitys.Count > 0)
                        {
                            continue;
                        }
                        Model.Info.Pvuv modelPvuv = new Model.Info.Pvuv();
                        modelPvuv.SKU = SKU;
                        modelPvuv.puTime = dtime;
                        modelPvuv.Uid = 63;
                        modelPvuv.CreateTime = DateTime.Now;
                        modelPvuv.KeyWord = g.keyWord;
                        modelPvuv.Iuv = g.iuv;
                        modelPvuv.Impression = g.impression;
                        modelPvuv.Crate = g.crate;
                        modelPvuv.Click = g.click;
                        modelPvuv.ClientType = clientType;
                        bll.AddEntity(modelPvuv);
                    }
                    foreach (Deal d in resulePvuv.res.deal)
                    {
                        var entitys = bll.LoadEntities(u => u.SKU == SKU && u.puTime == dtime && u.KeyWord == d.keyWord).ToList();
                        if (entitys.Count > 0)
                        {
                            Model.Info.Pvuv pu = entitys[0];
                            pu.Roc = d.roc;
                            pu.Num = d.num;
                            pu.AlipayNum = d.alipayNum;
                            bool _b = bll.UpdateEntity(pu);
                        }
                        else
                        {
                            Model.Info.Pvuv modelPvuv = new Model.Info.Pvuv();
                            modelPvuv.SKU = SKU;
                            modelPvuv.puTime = dtime;
                            modelPvuv.Uid = 63;
                            modelPvuv.CreateTime = DateTime.Now;
                            modelPvuv.KeyWord = d.keyWord;
                            modelPvuv.Num = d.num;
                            modelPvuv.Roc = d.roc;
                            modelPvuv.ClientType = clientType;
                            bll.AddEntity(modelPvuv);
                        }

                    }


                    return Content("Ok");
                }
                catch (Exception)
                {
                    return Content("Error");
                }

            }
            return Content("Error");
        }
    }

    public class Pvuv
    {
        public int rCode;
        public string message;
        public int elevenCode;
        public string elevenMsg;
        public Res res;

    }
    public class Res
    {
        public Guide[] guide;
        public Deal[] deal;
    }
    public class Guide
    {
        public string keyWord;
        public int impression;
        public int click;
        public string crate;
        public int iuv;
    }
    public class Deal
    {
        public string keyWord;
        public int alipayNum;
        public int num;
        public string roc;
    }
}
