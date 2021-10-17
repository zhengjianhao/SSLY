using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace zjh.SSLY.UI.Base
{
    public class BaseForm : Form
    {
        /// <summary>
        /// Excel文件操作工厂
        /// </summary>
        //public TransferDataFactory ExcelFactory = new TransferDataFactory();

        public BaseForm()
        {
            StartPosition = FormStartPosition.CenterScreen;//默认居中显示 
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(725, 517);
            this.Name = "BaseForm";
            this.ResumeLayout(false);

        }
    }

    //public abstract class AcitonService<T> where T : class,new()
    //{
    //    public AcitonService()
    //    {
    //        SetCurrentRepository();
    //    }
    //    public abstract void SetCurrentRepository();

    //    public IBaseService<T> CurrentService;

    //}
}
