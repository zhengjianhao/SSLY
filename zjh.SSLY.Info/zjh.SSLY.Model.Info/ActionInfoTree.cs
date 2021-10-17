using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zjh.SSLY.Model.Info
{
    public class ActionInfoTree : ActionInfo
    {
        public string iconCls;
        public List<ActionInfoTree> children;
        public string state;
        public string text;
        public bool checkeds = false; 
    }
}
