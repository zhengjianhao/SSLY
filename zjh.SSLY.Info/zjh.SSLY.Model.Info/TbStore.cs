//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace zjh.SSLY.Model.Info
{
    using System;
    using System.Collections.Generic;
    
    public partial class TbStore
    {
        public int ID { get; set; }
        public string Account { get; set; }
        public string Access_token { get; set; }
        public string Refresh_token { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> UID { get; set; }
        public string TaobaoUserId { get; set; }
        public Nullable<int> W2ExpiresIn { get; set; }
        public string TaobaoUserNick { get; set; }
        public Nullable<int> W1ExpiresIn { get; set; }
        public Nullable<int> ReExpiresIn { get; set; }
        public Nullable<int> ExpiresIn { get; set; }
        public string TokenType { get; set; }
        public Nullable<int> R1ExpiresIn { get; set; }
        public string SessionKey { get; set; }
    }
}
