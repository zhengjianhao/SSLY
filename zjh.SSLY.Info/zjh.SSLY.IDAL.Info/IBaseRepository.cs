using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace zjh.SSLY.IDAL.Info
{
    public interface IBaseRepository<T> where T : class ,new()
    {
        //要添加 System.Data.Entity的引用。
        T AddEntity(T entity);

        bool UpdateEntity(T entity);

        bool DeleteEntity(T entity);


        //规约模式
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda);

        IQueryable<T> LoadPageEntities<S>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, Expression<Func<T, S>> orderbyLambda, bool isAsc);
        bool AddEntity(List<T> entitys);
        zjh.SSLY.Model.Info.GetSequence_Result GetSequence(string prefix);
        int SpEditCategoryLoc(string pramTable, string pramCurID, string pramFID, string pramSort);


        /// <summary>
        /// 获取SN全局序列
        /// </summary>
        /// <returns></returns>
        string GetSn();

        string GetFormno();
        string Save(T hdr);

        DataTable GetData(string sql);
    }
}
