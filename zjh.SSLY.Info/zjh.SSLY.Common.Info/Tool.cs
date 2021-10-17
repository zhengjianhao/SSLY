using Ionic.Zip;
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
    /// 常用工具
    /// </summary>
    public static class Tool
    {

        #region Excel操作
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path">文件夹路径</param>
        /// <param name="refPath">返回路径</param>
        public static DataTable GetJoinExcel(string path, string refPath)
        {
            string[] paths = GetDir(path);
            TransferDataFactory factory = new TransferDataFactory();
            ITransferData csv = factory.GetUtil(DataFileType.CSV);
            DataTable dtcsv = csv.GetJoinData(paths);
            Stream stream = csv.GetStreamData(dtcsv);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            FileStream sr = File.Create(refPath);
            sr.Write(bytes, 0, bytes.Length);
            sr.Close();
            stream.Close();
            return dtcsv;

        }
        #endregion


        ///// <summary>
        ///// 类型转化，前提是两个集合对象有相同的字段
        ///// </summary>
        ///// <typeparam name="tInput"></typeparam>
        ///// <typeparam name="tOut"></typeparam>
        ///// <param name="objInput">源集合</param>
        ///// <param name="objOut">输出集合</param>
        //public static void ObjectConver<tInput, tOut>(List<tInput> objInput, ref List<tOut> objOut)
        //{
        //    foreach (tInput item in objInput)
        //    {
        //        PropertyInfo[] proMM = objInput.GetType().GetProperties();
        //        PropertyInfo[] ProTree = objOut.GetType().GetProperties();
        //        foreach (PropertyInfo field in proMM)
        //        {
        //            if (field.Name == "EntityState" || field.Name == "EntityKey")
        //            {
        //                continue;
        //            }
        //            var pinfo = ProTree.Where(u => u.Name == field.Name).ToList();
        //            if (pinfo.Count > 0)
        //            {
        //                pinfo[0].SetValue(objOut, field.GetValue(objInput));
        //            }
        //        }
        //    }
        //}

        //参数1：文件夹路径，参数2：要搜索的文件格式，参数3：指定搜索范围   （当前目录还是包含所有子目录）；   
        public static string[] GetDir(string DirFullPath)
        {
            string[] FileList = null;
            if (Directory.Exists(DirFullPath) == true)
            {
                FileList = Directory.GetFiles(DirFullPath, "*.*", SearchOption.TopDirectoryOnly);
            }
            return FileList;
        }


        public static void SendMail(MailMessage mm)
        {
            mm.Sender = new MailAddress("860358685@qq.com");
            mm.From = new MailAddress("860358685@qq.com");//发件人 
            mm.IsBodyHtml = true;
            mm.Priority = MailPriority.High;
            mm.BodyEncoding = System.Text.Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
            SmtpClient sc = new SmtpClient("smtp.qq.com");
            NetworkCredential nc = new NetworkCredential("860358685@qq.com", "hao6688168");
            sc.UseDefaultCredentials = true;
            sc.DeliveryMethod = SmtpDeliveryMethod.Network;
            sc.Credentials = nc;
            sc.EnableSsl = false;

            try
            {
                sc.Send(mm);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// 文件解压提取
        /// </summary>
        /// <param name="zipPath">Zip格式文件流</param>
        /// <param name="del">解压后原文件删除</param>
        /// <returns>解压后的文件路径</returns>
        public static string FileExtract(string zipPath, bool del = true)
        {
            using (ZipFile zip = new ZipFile(zipPath))
            {
                string path = Path.GetTempPath() + DateTime.Now.ToString("yyyyMMddHHmmssfffffff"); 
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                zip.ExtractAll(path, ExtractExistingFileAction.OverwriteSilently);
                return path;
            }
        }

    }
}
