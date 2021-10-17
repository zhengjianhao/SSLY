using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zjh.SSLY.UI.Base
{
    public partial class ListViewTz : ListView
    {
        public ListViewTz()
        {
            InitializeComponent();
        }
        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            e.DrawBackground();
      
        }
        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            base.OnDrawItem(e);
        }
        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
            base.OnDrawColumnHeader(e);
        }
    }
}
