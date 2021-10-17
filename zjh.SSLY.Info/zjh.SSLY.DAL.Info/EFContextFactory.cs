using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;
using zjh.SSLY.Model.Info;

namespace zjh.SSLY.DAL.Info
{
    public class EFContextFactory : IDbContextFactory
    {
        public System.Data.Objects.ObjectContext GetCurrentContextInstence()
        {
            //\return new ModelContainer();
            //从线程的上下文里面获取实例
            ObjectContext dbContext = (ObjectContext)CallContext.GetData(typeof(EFContextFactory).FullName);

            //如果没有获取到，实例为空。
            //
            if (dbContext == null)
            {
                //创建实例
                dbContext = new BabySSLYInfoEntities();

                //把实例放到线程 数据槽里面去了
                CallContext.SetData(typeof(EFContextFactory).FullName, dbContext);
            }

            return dbContext;
        }
    }
}
