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
    
    public partial class BuyersAccount
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<int> UID { get; set; }
        public string TbAccount { get; set; }
        public string TbPassword { get; set; }
        public string ZfbAccount { get; set; }
        public string ZfbPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Nullable<int> Credit { get; set; }
        public Nullable<System.DateTime> AccountTime { get; set; }
        public Nullable<int> State { get; set; }
        public string Remark { get; set; }
    }
}
