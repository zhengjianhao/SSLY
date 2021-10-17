using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.Model.Info;
using zjh.SSLY.TaoBao;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public class TbStoreController : Controller
    { 

        //
        // GET: /TbStore/ 
        public ActionResult Index()
        {
            //string code = Request["code"] == null ? "" : Request["code"].ToString();
            //Dictionary<string, string> dic = new Dictionary<string, string>();
            //dic.Add("code", code);
            //dic.Add("grant_type", "authorization_code");
            //dic.Add("client_id", "21801462");
            //dic.Add("client_secret", "6f3a279e4eed2a0830749c6b867220a7");
            //dic.Add("redirect_uri", "http://192.168.1.180:808/Default.aspx");
            //string url = "https://oauth.taobao.com/token";
            //string JSONResult = HttpWebResponseUtility.PostExecute(url, dic, null, "", Encoding.GetEncoding("GB2312"), null);

            //System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //Dictionary<string, string> dicResutl = jss.Deserialize<Dictionary<string, string>>(JSONResult);    //序列化为实体
            //TbStore tbs = new TbStore();
            //tbs.W2ExpiresIn = int.Parse(dicResutl["w2_expires_in"]);
            //tbs.TaobaoUserId = dicResutl["taobao_user_id"];
            //tbs.TaobaoUserNick = dicResutl["taobao_user_nick"];
            //tbs.W1ExpiresIn = int.Parse(dicResutl["w1_expires_in"]);
            //tbs.ReExpiresIn = int.Parse(dicResutl["re_expires_in"]);
            ////tbs.R1ExpiresIn =int.Parse( dicResutl["r2_expires_in"]);
            //tbs.ExpiresIn = int.Parse(dicResutl["expires_in"]);
            //tbs.TokenType = dicResutl["token_type"];
            //tbs.Refresh_token = dicResutl["refresh_token"];
            //tbs.Access_token = dicResutl["access_token"];
            //tbs.R1ExpiresIn = int.Parse(dicResutl["r1_expires_in"]);

            //try
            //{
            //    string UID = tbs.TaobaoUserId;
            //    //是否存在
            //    if (bll.LoadEntities(u => u.TaobaoUserId == UID).ToList().Count > 0)
            //    {
            //        bool up = bll.UpdateEntity(tbs);
            //        return View();
            //    }
            //    tbs = bll.AddEntity(tbs);
            //}
            //catch (Exception)
            //{
            //    throw;
            //}
            return View();
        }

    }
}
