using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.IDAL.Info
{
    public partial interface IDbSession
    {
        ObjectContext CurrentEFContext { get; set; }

        int ExcuteSql(string sql, params SqlParameter[] parameters);

        int SaveChanges(); 
    }
}
