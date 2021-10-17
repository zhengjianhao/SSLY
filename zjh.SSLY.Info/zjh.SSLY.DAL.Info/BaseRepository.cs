using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using zjh.SSLY.IDAL.Info;

namespace zjh.SSLY.DAL.Info
{
    public class BaseRepository<T> where T : class, new()
    {
        //解耦了 当前UserInfoRepository跟上下文的直接依赖。
        //保证了线程内上下文的实例唯一
        private IDbContextFactory dbContextFactory = new EFContextFactory();

        public string TableName = String.Empty;
        public string Prefix = String.Empty;

        private ObjectContext db;

     

        public BaseRepository()
        {
            db = dbContextFactory.GetCurrentContextInstence();
        }
        public T AddEntity(T entity)
        {
            if (entity == null)
            {
                return entity;
            }
            db.CreateObjectSet<T>().AddObject(entity);
            return entity;
        }
        public bool AddEntity(List<T> entitys)
        {
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    db.CreateObjectSet<T>().AddObject(item);
                }
                if (db.SaveChanges() > 0)
                {
                    return true;
                }
            }
            return false;
        }
        public bool UpdateEntity(T entity)
        {

            db.CreateObjectSet<T>().ApplyCurrentValues(entity);
            db.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified);
            //if (db.SaveChanges() > 0)Attach(entity);
            //{
            //    return true;
            //}
            //return false;

            return true;
        }

        public bool DeleteEntity(T entity)
        {
            //删除的时候只需要 处理主键就可以了
            //var entity = new UserInfo() {ID =  id};
            //db.UserInfo.Attach(entity);
            //db.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);
            //if (db.SaveChanges() > 0)
            //{
            //    return true;
            //}
            //return false;

            bool result = true;

            if (entity != null)
            {
                db.CreateObjectSet<T>().Attach(entity);
                db.ObjectStateManager.ChangeObjectState(entity, EntityState.Deleted);

                //if(db.SaveChanges() > 0)
                //{
                //    result = true;
                //}
            }
            return result;


        }

        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLambda)
        {
            return db.CreateObjectSet<T>().Where<T>(whereLambda).AsQueryable();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="S"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<S>(Expression<Func<T, bool>> whereLambda, int pageIndex, int pageSize, out int totalCount, Expression<Func<T, S>> orderbyLambda, bool isAsc)
        {
            var temp = db.CreateObjectSet<T>().Where<T>(whereLambda);

            totalCount = temp.Count();

            if (isAsc)
            {
                var result = temp.OrderBy<T, S>(orderbyLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);
                return result.AsQueryable();
            }
            else
            {

                var result = temp.OrderByDescending<T, S>(orderbyLambda)
                    .Skip<T>(pageSize * (pageIndex - 1))
                    .Take<T>(pageSize);
                return result.AsQueryable();
            }
        }



        public zjh.SSLY.Model.Info.GetSequence_Result GetSequence(string prefix)
        {
            ObjectParameter param = new ObjectParameter("prefix", Type.GetType("System.String"));
            param.Value = TableName + prefix;
            ObjectResult<zjh.SSLY.Model.Info.GetSequence_Result> data = db.ExecuteFunction<zjh.SSLY.Model.Info.GetSequence_Result>("GetSequence", param);
            zjh.SSLY.Model.Info.GetSequence_Result _R = (zjh.SSLY.Model.Info.GetSequence_Result)data.FirstOrDefault();
            return _R;
        }



        /// <summary>
        /// 获取SN全局序列
        /// </summary>
        /// <returns></returns>
        public string GetSn()
        {
            ObjectParameter param = new ObjectParameter("prefix", Type.GetType("System.String"));
            param.Value = "SystemSn";
            ObjectResult<zjh.SSLY.Model.Info.GetSequence_Result> data = db.ExecuteFunction<zjh.SSLY.Model.Info.GetSequence_Result>("GetSequence", param);
            zjh.SSLY.Model.Info.GetSequence_Result _R = (zjh.SSLY.Model.Info.GetSequence_Result)data.FirstOrDefault();
            return DateTime.Now.ToString("yyyyMMdd") + _R.id.ToString().PadLeft(7, '0');
        }








        public int SpEditCategoryLoc(string pramTable, string pramCurID, string pramFID, string pramSort)
        {
            ObjectParameter pTable = new ObjectParameter("pramTable", Type.GetType("System.String"));
            pTable.Value = pramTable;
            ObjectParameter pCurID = new ObjectParameter("pramCurID", Type.GetType("System.String"));
            pCurID.Value = pramCurID;
            ObjectParameter pFID = new ObjectParameter("pramFID", Type.GetType("System.String"));
            pFID.Value = pramFID;
            ObjectParameter pSort = new ObjectParameter("pramSort", Type.GetType("System.String"));
            pSort.Value = pramSort;

            return db.ExecuteFunction("sp_EditCategoryLoc", pTable, pCurID, pFID, pSort);
        }

        public string GetFormno()
        {
            var data = GetSequence(Prefix);
            return Prefix + DateTime.Now.ToString("yyMM") + data.id.ToString().PadLeft(5, '0');
        }


        public string Save(T hdr)
        {
            DbSessionFactory dbf = new DbSessionFactory();
            IDbSession dbs = dbf.GetCurrentSession();
            //var data = GetSequence(Prefix);
            //string Formno = Prefix + DateTime.Now.ToString("yyMM") + data.id.ToString().PadLeft(5, '0');

            string Formno = GetFormno();
            SetObjPropertyValue("Formno", Formno, hdr);
            AddEntity(hdr);
            bool _r = dbs.SaveChanges() > 0;
            if (_r)
            {
                return Formno;
            }
            return "";
        }


        /// <summary>
        /// 通过反射设置对象的属性值
        /// </summary>
        /// <param name="FieldName"></param>
        /// <param name="Value"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SetObjPropertyValue(string FieldName, string Value, object obj)
        {
            try
            {
                Type Ts = obj.GetType();
                object v = Convert.ChangeType(Value, Ts.GetProperty(FieldName).PropertyType);
                Ts.GetProperty(FieldName).SetValue(obj, v, null);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public DataTable GetData(string sql)
        { 
            return SqlHelper.GetData(sql);
        }
    }

}
