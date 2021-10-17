using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.IBLL.Info
{
    public interface IBaseService<T> where T : class, new()
    {        //要添加 System.Data.Entity的引用。
        T AddEntity(T entity);

        bool AddEntity(List<T> entitys);

        bool UpdateEntity(T entity);

        bool UpdateEntity(List<T> entitys);

        bool DeleteEntity(T entity);

        //规约模式
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<S>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, Expression<Func<T, S>> orderbyLambda, bool isAsc);

        string CreateFormno(string id);

        int SpEditCategoryLoc(string pramTable, string pramCurID, string pramFID, string pramSort);


    

    }
}
