using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace zjh.SSLY.UI.MvcMain.Controllers
{
    public abstract class BaseController: Controller
    {
        //public 
        public BaseController()
        {
            CurUid = 63;

        }
        public int CurUid = 0; 
    }
}
