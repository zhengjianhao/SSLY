using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.Model.Info
{
    /// <summary>
    /// 返回客户端类
    /// </summary>
    public class ResponseData
    {
        public string Content { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessges { get; set; }
        public string CallTime { get; set; }
    }
}
