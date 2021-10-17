using System.Web;
using System.Web.Mvc;

namespace zjh.SSLY.UI.MvcMain
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}