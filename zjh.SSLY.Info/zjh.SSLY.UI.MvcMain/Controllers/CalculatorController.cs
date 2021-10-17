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

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    //[Authorize]
    //[InitializeSimpleMembership]
    public class CalculatorController : Controller
    {
        // 
        public ActionResult Index()
        {
            return View();
        }
    }
}
