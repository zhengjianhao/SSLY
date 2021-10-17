using LumenWorks.Framework.IO.Csv;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.Common.Info
{



    /// <summary>
    /// 支持XLS，XLSX，CSV格式文件读取
    /// </summary>
    public interface ITransferData
    {
        Stream GetStreamData(DataTable dt);
        DataTable GetData(Stream stream);
        DataTable GetData(string filePath);
        DataTable GetJoinData(string[] path);
    }


    public class CsvTransferData : ITransferData
    {

        public Stream GetStream(DataTable table)
        {
            StringBuilder sb = new StringBuilder();
            if (table != null && table.Columns.Count > 0 && table.Rows.Count > 0)
            {
                foreach (DataRow item in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        if (item[i] != null)
                        {
                            sb.Append("\"").Append(item[i].ToString().Replace("\"", "\"\"")).Append("\"");
                        }
                    }
                    sb.Append("\n");
                }
            }
            MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(sb.ToString()));
            return stream;
        }

        public DataTable GetData(Stream stream)
        {
            int curIndex = 0;
            using (stream)
            {
                using (StreamReader input = new StreamReader(stream, Encoding.Default))
                {
                    using (CsvReader csv = new CsvReader(input, false))
                    {
                        DataTable dt = new DataTable();
                        int columnCount = csv.FieldCount;
                        while (csv.ReadNextRecord())
                        {
                            if (curIndex == 0)
                            {
                                for (int i = 0; i < columnCount; i++)
                                {
                                    dt.Columns.Add(new DataColumn(csv[i]));
                                }
                            }
                            else
                            {
                                DataRow dr = dt.NewRow();
                                for (int i = 0; i < columnCount; i++)
                                {
                                    if (!string.IsNullOrWhiteSpace(csv[i]))
                                    {
                                        dr[i] = csv[i];
                                    }
                                }
                                dt.Rows.Add(dr);
                            }
                            curIndex++;
                        }
                        return dt;
                    }

                }
            }
        }

        public DataTable GetJoinData(string[] path)
        {

            DataTable dt = new DataTable();
            bool fist = true;

            foreach (var p in path)
            {
                using (StreamReader input = new StreamReader(p, Encoding.Default))
                {

                    using (CsvReader csv = new CsvReader(input, false))
                    {
                        int curIndex = 0;
                        int columnCount = csv.FieldCount;
                        while (csv.ReadNextRecord())
                        {
                            if (fist)
                            {
                                for (int i = 0; i < columnCount; i++)
                                {
                                    dt.Columns.Add(csv[i]);//标题
                                }
                                fist = false;
                                curIndex++;
                            }

                            if (curIndex > 0)
                            {
                                DataRow dr = dt.NewRow();
                                for (int i = 0; i < columnCount; i++)
                                {
                                    if (!string.IsNullOrWhiteSpace(csv[i]))
                                    {
                                        dr[i] = csv[i];
                                    }
                                }
                                dt.Rows.Add(dr);
                            }
                            curIndex++;

                        }

                    }
                }
            }
            return dt;
        }


        public Stream GetStreamData(DataTable table)
        {
            StringBuilder sb = new StringBuilder();
            if (table != null && table.Columns.Count > 0 && table.Rows.Count > 0)
            {
                foreach (DataRow item in table.Rows)
                {
                    for (int i = 0; i < table.Columns.Count; i++)
                    {
                        if (i > 0)
                        {
                            sb.Append(",");
                        }
                        if (item[i] != null)
                        {
                            sb.Append("\"").Append(item[i].ToString().Replace("\"", "\"\"")).Append("\"");
                        }
                    }
                    sb.Append("\n");
                }
            }
            MemoryStream stream = new MemoryStream(Encoding.Default.GetBytes(sb.ToString()));
            return stream;
        }


        public DataTable GetData(string filePath)
        {
            using (FileStream fs = new FileStream(filePath,FileMode.Open))
            {
                return GetData(fs);
            }
        }
    }

    public class XlsxTransferData : ITransferData
    {

        public Stream GetStreamData(DataTable dt)
        {
            throw new NotImplementedException();
        }

        public DataTable GetData(Stream stream)
        {

            throw new NotImplementedException();
        }


        public DataTable GetJoinData(string[] path)
        {
            throw new NotImplementedException();
        }


        public DataTable GetData(string filePath)
        {
            throw new NotImplementedException();
        }
    }

    public class XlsTransferData : ITransferData
    {

        public Stream GetStreamData(DataTable dt)
        {
            throw new NotImplementedException();
        }

        public DataTable GetData(Stream stream)
        {
            throw new NotImplementedException();
        }


        public DataTable GetJoinData(string[] path)
        {
            throw new NotImplementedException();
        }


        public DataTable GetData(string filePath)
        {
            throw new NotImplementedException();
        }
    }


    public class TransferDataFactory
    {

        public ITransferData GetUtil(DataFileType dfType)
        {
            switch (dfType)
            {
                case DataFileType.CSV:
                    return new CsvTransferData();
                case DataFileType.XLS:
                    return new XlsTransferData();
                case DataFileType.XLSX:
                    return new XlsxTransferData();
                default:
                    return new CsvTransferData();
            }
        }
    }
    public enum DataFileType
    {
        CSV,
        XLS,
        XLSX
    }

}
