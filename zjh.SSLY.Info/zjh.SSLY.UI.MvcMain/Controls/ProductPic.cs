using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using zjh.SSLY.BLL.Info;
using zjh.SSLY.IBLL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain.Controls
{
    public class ProductPic
    {
        /// <summary>
        /// Lable文本
        /// </summary>
        /// <param name="fortarget">for属性</param>
        /// <param name="text">显示文本</param>
        /// <returns></returns>
        public static MvcHtmlString PicTable(string SKU)
        {
            IDocumentService bllDoc = new DocumentService();
            List<Document> docs = bllDoc.LoadEntities(u => u.SKU == SKU).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<table>");
            int j = 0;
            for (int i = 0; i < docs.Count; i++)
            {
                Document doc = docs[i];
                j++;
                if (j == 1)
                {
                    sb.AppendLine("<tr>");
                }
                sb.AppendLine("<td style=\"  padding: 9px;width: 180px;height: 180px;\" > <img style=\"width: 180px;\" src='" + doc.Path + "'/><a href=\"javascript:void(0)\" onclick=DelPic(" + doc.ID + ")>删除</a>  <a href=\"javascript:void(0)\" onclick=SetZImage(" + doc.ID + ",'" + doc.SKU + "')>设置主图</a></td>");
                if (j % 4 == 0 || j == docs.Count + 1)
                {
                    sb.AppendLine("</tr>");
                }
            }
            sb.AppendLine("</table>");



            return new MvcHtmlString(sb.ToString());
        }

    }
}