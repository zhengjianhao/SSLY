using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain
{


    /// <summary>
    /// 物流ShippingArea
    /// </summary>
    public interface IShippingSheet
    {

        /// <summary>
        /// Excel 解析  格式1
        /// </summary>
        /// <param name="excel"></param>
        /// <returns></returns>
        List<ShippingArea> ReadingData1(Stream excel, int shippingID);

        /// <summary>
        /// Excel 解析 格式2
        /// </summary>
        /// <param name="excel"></param>
        /// <returns></returns>
        List<ShippingArea> ReadingData2(Stream excel, int shippingID);




        /// <summary>
        /// Excel 解析 格式3  按价格*重量格式
        /// </summary>
        /// <param name="excel"></param>
        /// <returns></returns>
        List<ShippingArea> ReadingDataPriceWeight(Stream excel, int shippingID);







        /// <summary>
        /// 导入EXCEl数据进ShippingArea表
        /// </summary>
        /// <param name="excel"></param>
        /// <returns></returns>
        bool ImportShippingArea(Stream excel, int shippingID, int sheetType);

    }


    /// <summary>
    /// IShippingSheet物流工厂
    /// </summary>
    public static class ShippingStorage
    {
        /// <summary>
        /// 根据shippingID创建ShippingSheet
        /// </summary>
        /// <param name="shippingID"></param>
        /// <returns></returns>
        public static IShippingSheet CreateSheet()
        {
            return new ShippingSheet();
        }
    }

}
