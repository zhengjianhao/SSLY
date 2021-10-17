using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks; 
using System.Web;
using Top.Api.Domain;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response; 

namespace zjh.SSLY.TaoBao
{
    public class API
    {        //TaobaoClient client=new DefaultTaobaoClient(url, appkey, secret);
        //TradesSoldGetRequest req=new TradesSoldGetRequest();
        //req.setFields("seller_nick,buyer_nick,title,type,created,sid,tid,seller_rate,buyer_rate,status,payment,discount_fee,adjust_fee,post_fee,total_fee,pay_time,end_time,modified,consign_time,buyer_obtain_point_fee,point_fee,real_point_fee,received_payment,commission_fee,pic_path,num_iid,num_iid,num,price,cod_fee,cod_status,shipping_type,receiver_name,receiver_state,receiver_city,receiver_district,receiver_address,receiver_zip,receiver_mobile,receiver_phone,orders.title,orders.pic_path,orders.price,orders.num,orders.iid,orders.num_iid,orders.sku_id,orders.refund_status,orders.status,orders.oid,orders.total_fee,orders.payment,orders.discount_fee,orders.adjust_fee,orders.sku_properties_name,orders.item_meal_name,orders.buyer_rate,orders.seller_rate,orders.outer_iid,orders.outer_sku_id,orders.refund_id,orders.seller_type");
        //req.setPageNo(1L);
        //req.setPageSize(30L);
        //TradesSoldGetResponse response = client.execute(req , sessionKey);
        //session: 6100e001104795c7d92af4dbcfb6a94cba7ab647680b5a2173519345
        //refresh_token: 6101700f1de93673b081d29f3f7a466f93bd6cb65b12aed173519345
        //TaobaoClient
        public string url = "http://gw.api.taobao.com/router/rest";
        public string appkey = "21801462";
        public string appsecret = "6f3a279e4eed2a0830749c6b867220a7";
        public string sessionKey = string.Empty;

        /// <summary>
        /// 获取授权
        /// </summary>
        public string Sq = "https://oauth.taobao.com/authorize?response_type=token&client_id=21801462";




        //授权地址
        //https://oauth.taobao.com/authorize?response_type=code&client_id=21801462&redirect_uri=http://192.168.1.180:808/Default.aspx&state=1212&view=web


        //回调地址
        //http://192.168.1.180:808/Default.aspx?code=sscmzybsY6ipo1G7es8iq8fo26200&state=1212



        TradeOrderInfo trade = new TradeOrderInfo();
        public void LoadOrder()
        { 
            ITopClient client = new DefaultTopClient(url, appkey, appsecret);
            AftersaleGetRequest req = new AftersaleGetRequest();
            AftersaleGetResponse response = client.Execute(req, sessionKey);
        }
    }

    /// <summary>  
    /// 有关HTTP请求的辅助类  
    /// </summary>  
    public class HttpWebResponseUtility
    {
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Method = "GET";
            request.UserAgent = DefaultUserAgent;
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            return request.GetResponse() as HttpWebResponse;
        }


        public static HttpWebResponse CreatePostHttpResponse(string url, MultipartForm form, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            request.ContentType = form.ContentType;
            request.ContentLength = form.FormData.Length;
            request.KeepAlive = true;
            if (form != null)
            {
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(form.FormData, 0, form.FormData.Length);
                }

            }
            return request.GetResponse() as HttpWebResponse;
        }

        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }
            if (requestEncoding == null)
            {
                throw new ArgumentNullException("requestEncoding");
            }
            HttpWebRequest request = null;
            //如果是发送HTTPS请求  
            if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                request = WebRequest.Create(url) as HttpWebRequest;
                request.ProtocolVersion = HttpVersion.Version10;
            }
            else
            {
                request = WebRequest.Create(url) as HttpWebRequest;
            }
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";

            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            else
            {
                request.UserAgent = DefaultUserAgent;
            }

            if (timeout.HasValue)
            {
                request.Timeout = timeout.Value;
            }
            if (cookies != null)
            {
                request.CookieContainer = new CookieContainer();
                request.CookieContainer.Add(cookies);
            }
            //如果需要POST数据  
            if (!(parameters == null || parameters.Count == 0))
            {
                StringBuilder buffer = new StringBuilder();
                int i = 0;
                foreach (string key in parameters.Keys)
                {
                    if (i > 0)
                    {
                        buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                    }
                    else
                    {
                        buffer.AppendFormat("{0}={1}", key, parameters[key]);
                    }
                    i++;
                }
                byte[] data = requestEncoding.GetBytes(buffer.ToString());
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }
            return request.GetResponse() as HttpWebResponse;
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }


        #region 执行请求：GET，POST
        /// <summary>
        ///  Get执行api，并返回JSON
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <param name="userAgent"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static string GetExecute(string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            string result = "";
            try
            {
                HttpWebResponse respose = HttpWebResponseUtility.CreateGetHttpResponse(url, timeout, userAgent, cookies);
                //string stausCode = respose.StatusCode.ToString();
                Stream respStream = respose.GetResponseStream();
                Stream st = respose.GetResponseStream();
                using (StreamReader sr = new StreamReader(st, Encoding.GetEncoding("GB2312")))
                {
                    result = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// Post执行api，并返回JSON
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <param name="userAgent"></param>
        /// <param name="requestEncoding"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static string PostExecute(string url, MultipartForm form, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            string result = "";
            try
            {
                HttpWebResponse respose = HttpWebResponseUtility.CreatePostHttpResponse(url, form, timeout, userAgent, requestEncoding, cookies);
                Stream respStream = respose.GetResponseStream();
                Stream st = respose.GetResponseStream();
                using (StreamReader sr = new StreamReader(st, Encoding.GetEncoding("GB2312")))
                {
                    result = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;

        }

        /// <summary>
        /// Post执行api，并返回JSON
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <param name="timeout"></param>
        /// <param name="userAgent"></param>
        /// <param name="requestEncoding"></param>
        /// <param name="cookies"></param>
        /// <returns></returns>
        public static string PostExecute(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            string result = "";
            try
            {
                HttpWebResponse respose = HttpWebResponseUtility.CreatePostHttpResponse(url, parameters, timeout, userAgent, requestEncoding, cookies);
                Stream respStream = respose.GetResponseStream();
                Stream st = respose.GetResponseStream();
                using (StreamReader sr = new StreamReader(st, Encoding.GetEncoding("GB2312")))
                {
                    result = sr.ReadToEnd();
                }

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            return result;
        }
        #endregion
    
    }

    /// <summary>    
    /// 对文件和文本数据进行Multipart形式的编码    
    /// </summary>    
    public class MultipartForm
    {
        private Encoding encoding;
        private MemoryStream ms;
        private string boundary;
        private byte[] formData;
        /// <summary>    
        /// 获取编码后的字节数组    
        /// </summary>    
        public byte[] FormData
        {
            get
            {
                if (formData == null)
                {
                    byte[] buffer = encoding.GetBytes("--" + this.boundary + "--\r\n");
                    ms.Write(buffer, 0, buffer.Length);
                    formData = ms.ToArray();
                }
                return formData;
            }
        }
        /// <summary>    
        /// 获取此编码内容的类型    
        /// </summary>    
        public string ContentType
        {
            get { return string.Format("multipart/form-data; boundary={0}", this.boundary); }
        }
        /// <summary>    
        /// 获取或设置对字符串采用的编码类型    
        /// </summary>    
        public Encoding StringEncoding
        {
            set { encoding = value; }
            get { return encoding; }
        }
        /// <summary>    
        /// 实例化    
        /// </summary>    
        public MultipartForm()
        {
            boundary = string.Format("--{0}--", Guid.NewGuid());
            ms = new MemoryStream();
            encoding = Encoding.Default;
        }
        /// <summary>    
        /// 添加一个文件    
        /// </summary>    
        /// <param name="name">文件域名称</param>    
        /// <param name="filename">文件的完整路径</param>    
        public void AddFlie(string name, string filename)
        {
            if (!System.IO.File.Exists(filename))
                throw new FileNotFoundException("尝试添加不存在的文件。", filename);
            FileStream fs = null;
            byte[] fileData = { };
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                fileData = new byte[fs.Length];
                fs.Read(fileData, 0, fileData.Length);
                this.AddFlie(name, Path.GetFileName(filename), fileData, fileData.Length);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }
        /// <summary>    
        /// 添加一个文件    
        /// </summary>    
        /// <param name="name">文件域名称</param>    
        /// <param name="filename">文件名</param>    
        /// <param name="fileData">文件二进制数据</param>    
        /// <param name="dataLength">二进制数据大小</param>    
        public void AddFlie(string name, string filename, byte[] fileData, int dataLength)
        {
            if (dataLength <= 0 || dataLength > fileData.Length)
            {
                dataLength = fileData.Length;
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("--{0}\r\n", this.boundary);
            sb.AppendFormat("Content-Disposition: form-data; name=\"{0}\";filename=\"{1}\"\r\n", name, filename);
            sb.AppendFormat("Content-Type: {0}\r\n", this.GetContentType(filename));
            sb.Append("\r\n");
            byte[] buf = encoding.GetBytes(sb.ToString());
            ms.Write(buf, 0, buf.Length);
            ms.Write(fileData, 0, dataLength);
            byte[] crlf = encoding.GetBytes("\r\n");
            ms.Write(crlf, 0, crlf.Length);
        }

        public void AddFlie(string name, HttpPostedFile file)
        {
            byte[] fileData = { };
            try
            {
                fileData = new byte[file.InputStream.Length];
                file.InputStream.Read(fileData, 0, fileData.Length);
            }
            catch (Exception)
            {
                throw;
            }
            this.AddFlie(name, file.FileName, fileData, fileData.Length);
        }

        /// <summary>    
        /// 添加字符串    
        /// </summary>    
        /// <param name="name">文本域名称</param>    
        /// <param name="value">文本值</param>    
        public void AddString(string name, string value)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("--{0}\r\n", this.boundary);
            sb.AppendFormat("Content-Disposition: form-data; name=\"{0}\"\r\n", name);
            sb.Append("\r\n");
            sb.AppendFormat("{0}\r\n", value);
            byte[] buf = encoding.GetBytes(sb.ToString());
            ms.Write(buf, 0, buf.Length);
        }
        /// <summary>    
        /// 从注册表获取文件类型    
        /// </summary>    
        /// <param name="filename">包含扩展名的文件名</param>    
        /// <returns>如：application/stream</returns>    
        private string GetContentType(string filename)
        {
            Microsoft.Win32.RegistryKey fileExtKey = null; ;
            string contentType = "application/stream";
            try
            {
                fileExtKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(Path.GetExtension(filename));
                contentType = fileExtKey.GetValue("Content Type", contentType).ToString();
            }
            finally
            {
                if (fileExtKey != null) fileExtKey.Close();
            }
            return contentType;
        }
    }
}
