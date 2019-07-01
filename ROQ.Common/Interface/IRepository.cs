using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ROQ.Common.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(long id, Boolean RefreshContext = false);
        IEnumerable<TEntity> GetAll(Boolean RefreshContext = false);
        IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate, Boolean RefreshContext = false);
        TEntity FindBy_FirstOrDefault(Expression<Func<TEntity, bool>> predicate, Boolean RefreshContext = false);

        int GetCount();
        int GetCount(Expression<Func<TEntity, bool>> predicate);

        void MarkModified(TEntity entity);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Delete(long id);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);

        void Edit(TEntity entity);
        void EditRange(IEnumerable<TEntity> entities);

        void Save();

        List<TEntity> GetWithRawSql(string query, params object[] parameters);
    }
}
