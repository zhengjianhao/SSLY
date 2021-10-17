using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;

namespace zjh.SSLY.DAL.Info
{
    public partial class DbSession : IDbSession
    {
        //当前EF上下午属性
        public ObjectContext CurrentEFContext { get; set; }

        private IDbContextFactory dbContextFactory = new EFContextFactory();

        public DbSession()
        {
            this.CurrentEFContext = dbContextFactory.GetCurrentContextInstence();
        }

        public int ExcuteSql(string sql, params System.Data.SqlClient.SqlParameter[] parameters)
        {
            return this.CurrentEFContext.ExecuteStoreCommand(sql, parameters);
        }

        public int SaveChanges()
        {
            return this.CurrentEFContext.SaveChanges();
        }

 

  

    }
}
