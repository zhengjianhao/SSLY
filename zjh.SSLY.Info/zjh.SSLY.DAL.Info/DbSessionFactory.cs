using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;

namespace zjh.SSLY.DAL.Info
{
    public class DbSessionFactory : IDbSessionFactory
    {
        public IDbSession GetCurrentSession()
        {
            IDbSession dbSession = (IDbSession)CallContext.GetData(typeof(DbSessionFactory).FullName);

            if (dbSession == null)
            {
                dbSession = new DbSession();
                CallContext.SetData(typeof(DbSessionFactory).FullName, dbSession);
            }
            return dbSession;
        }
    }
}
