using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.IDAL.Info
{
    public interface IDbContextFactory
    {
        ObjectContext GetCurrentContextInstence();
    }
}
