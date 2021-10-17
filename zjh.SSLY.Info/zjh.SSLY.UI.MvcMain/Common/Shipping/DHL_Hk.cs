using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain
{



    public class ShippingSheet : IShippingSheet
    { 




        /// <summary>
        ///  导入EXCEl数据进ShippingArea表
        /// </summary>
        /// <param name="excel"></param>
        /// <param name="shippingID"></param>
        /// <returns></returns>
        public bool ImportShippingArea(Stream excel, int shippingID, int sheetType)
        {
            if (sheetType==1)
            {
                zjh.SSLY.IBLL.Info.IShippingAreaService bll = new BLL.Info.ShippingAreaService();
                List<ShippingArea> li = this.ReadingData1(excel, shippingID).OrderBy(u => u.EndWeight).ToList();
                return bll.AddEntity(li);
            }
            if (sheetType == 3)
            {
                zjh.SSLY.IBLL.Info.IShippingAreaService bll = new BLL.Info.ShippingAreaService();
                List<ShippingArea> li = this.ReadingDataPriceWeight(excel, shippingID).OrderBy(u => u.EndWeight).ToList();
                return bll.AddEntity(li);
            }
            return false;
        }

        /// <summary>
        /// 读取Excel数据，格式1读取
        /// </summary>
        /// <param name="excel"></param>
        /// <param name="shippingID"></param>
        /// <returns></returns>
        public List<ShippingArea> ReadingData1(Stream excel, int shippingID)
        {
            HSSFWorkbook hssfWork = new HSSFWorkbook(excel);
            ISheet sheet = hssfWork.GetSheetAt(0);

            int rowNum = sheet.LastRowNum;
            List<string> country = new List<string>();
            List<string> area = new List<string>();

            List<ShippingArea> liShippingArea = new List<ShippingArea>();

            for (int i = 2; i < rowNum; i++)
            {
                int cellNum = sheet.GetRow(0).LastCellNum;
                for (int j = 1; j < cellNum; j++)
                {
                    ShippingArea sa = new ShippingArea();
                    sa.Shipping_ID = shippingID;
                    sa.Uid = 0;
                    sa.FirstPrice = 0;
                    sa.AdditionalCost = 0;
                    sa.ContinuePrice = 0;
                    sa.ContinueWeight = 0;
                    sa.FuelCost = 0;
                    sa.Discount = 0;
                    sa.Price = 0;
                    sa.Weight = 0;

                    sa.FirstWeight = 0;
                    if (i != 2)
                        sa.FirstWeight = decimal.Parse(sheet.GetRow(i - 1).GetCell(0).ToString()) * 1000;//开始重量

                    sa.EndWeight = decimal.Parse(sheet.GetRow(i).GetCell(0).ToString()) * 1000;//结束重量

                    sa.Area = sheet.GetRow(1).GetCell(j).ToString();//区域
                    sa.CountryGroup = sheet.GetRow(0).GetCell(j).ToString();//国家
                    sa.IntervalPirce = decimal.Parse(sheet.GetRow(i).GetCell(j).ToString());//价格
                    sa.CreateTime = DateTime.Now;
                    liShippingArea.Add(sa);
                }

            }
            return liShippingArea;
        }

        public List<ShippingArea> ReadingData2(Stream excel, int shippingID)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 读取excel数据，存价格重量格式
        /// </summary>
        /// <param name="excel"></param>
        /// <param name="shippingID"></param>
        /// <returns></returns>
        public List<ShippingArea> ReadingDataPriceWeight(Stream excel, int shippingID)
        {
            HSSFWorkbook hssfWork = new HSSFWorkbook(excel);
            ISheet sheet = hssfWork.GetSheetAt(0);

            int rowNum = sheet.LastRowNum;
            List<string> country = new List<string>();
            List<string> area = new List<string>();

            List<ShippingArea> liShippingArea = new List<ShippingArea>();

            for (int i = 2; i < rowNum; i++)
            {
                int cellNum = sheet.GetRow(0).LastCellNum;
                for (int j = 1; j < cellNum; j++)
                {
                    ShippingArea sa = new ShippingArea();
                    sa.Shipping_ID = shippingID;
                    sa.Uid = 0;
                    sa.FirstPrice = 0;
                    sa.AdditionalCost = 0;
                    sa.ContinuePrice = 0;
                    sa.ContinueWeight = 0;
                    sa.FuelCost = 0;
                    sa.Discount = 0;
                    sa.IntervalPirce = 0;
                    sa.EndWeight = 0;

                    sa.FirstWeight = 0;
                    if (i != 2)
                        sa.FirstWeight = decimal.Parse(sheet.GetRow(i - 1).GetCell(0).ToString()) * 1000;//开始重量

                    //sa.Weight = decimal.Parse(sheet.GetRow(i).GetCell(0).ToString()) * 1000;//重量
                    sa.Weight = 1000;//按公斤计费
                    sa.Area = sheet.GetRow(1).GetCell(j).ToString();//区域
                    sa.CountryGroup = sheet.GetRow(0).GetCell(j).ToString();//国家
                    sa.Price = decimal.Parse(sheet.GetRow(i).GetCell(j).ToString());//价格
                    sa.CreateTime = DateTime.Now;
                    liShippingArea.Add(sa);
                }

            }
            return liShippingArea; 
        }
    }
}
