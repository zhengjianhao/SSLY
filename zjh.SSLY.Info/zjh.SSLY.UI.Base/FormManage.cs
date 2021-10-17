using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zjh.SSLY.UI.Base
{ 
    /// <summary>
    /// Dilog窗口操作
    /// </summary>
    /// <param name="dlg"></param>
    /// <param name="isClose"></param>
    public delegate void DlgStateDelegate(Form dlg, bool isClose);
}
