using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.DAL.Info;
using zjh.SSLY.IDAL.Info;

namespace zjh.SSLY.BLL.Info
{
    public abstract class BaseService<T> where T : class,new()
    {
        public IDbSessionFactory DbSessionFactory = new DbSessionFactory();

        public IDbSession dbSession;
        public BaseService()
        {
            dbSession = DbSessionFactory.GetCurrentSession();

            //构造里面 调用了 设置当前仓储的 纯抽象方法，由于多太，调用子类里面的设置当前仓储的  实现
            SetCurrentRepository();
        }
        public abstract void SetCurrentRepository();

        public IBaseRepository<T> CurrentRepository;

        public T AddEntity(T entity)
        {
            T t = CurrentRepository.AddEntity(entity);
            dbSession.SaveChanges();
            return t;
        }
        public bool UpdateEntity(T entity)
        {
            CurrentRepository.UpdateEntity(entity);
            if (dbSession.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteEntity(T entity)
        {
            CurrentRepository.DeleteEntity(entity);
            if (dbSession.SaveChanges() > 0)
            {
                return true;
            }
            return false;
        }


        public bool AddEntity(List<T> entitys)
        {
            foreach (T entity in entitys)
            {
                T t = CurrentRepository.AddEntity(entity);
            }
            return dbSession.SaveChanges() > 0;

        }


        public bool UpdateEntity(List<T> entitys)
        {
            foreach (T entity in entitys)
            {
                CurrentRepository.UpdateEntity(entity);
            }
            return dbSession.SaveChanges() > 0;
        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return CurrentRepository.LoadEntities(whereLambda);
        }

        public IQueryable<T> LoadPageEntities<S>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            return CurrentRepository.LoadPageEntities(whereLambda, pageIndex, pageSize, out totalCount, orderbyLambda, isAsc);
        }

        public string CreateFormno(string id)
        {
            return DateTime.Now.Year.ToString().Substring(2, 2) + id.PadLeft(8, '0');
        }

        public int SpEditCategoryLoc(string pramTable, string pramCurID, string pramFID, string pramSort)
        {
            return CurrentRepository.SpEditCategoryLoc(pramTable, pramCurID, pramFID, pramSort);
        }


        public string GetSn()
        {
            return CurrentRepository.GetSn();
        }


    }
}
