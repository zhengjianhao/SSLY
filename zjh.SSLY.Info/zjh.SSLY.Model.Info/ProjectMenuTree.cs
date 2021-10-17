using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.Model.Info
{
    public class ProjectMenuTree : ProjectMenu
    { 
        public List<ProjectMenuTree> children;
        public string state;
        public bool checkeds = false;
    }
}
