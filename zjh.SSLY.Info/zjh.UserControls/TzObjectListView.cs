using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zjh.UserControls
{
    public class TzObjectListView : ObjectListView
    {
    
    }

    public class TzObjectListViewItem
    {
        public string AspectName { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Width { get; set; }
        public int DisplayIndex { get; set; }

        public HorizontalAlignment TextAlign { get; set; }
    }


}
