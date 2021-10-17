using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.UI.MvcMain
{
    public class ProductTz : ProductDtl, IEnumerable
    { 
        public string Age;
        public decimal? Price;

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}