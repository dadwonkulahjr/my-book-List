using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MyBookList.Services.Repository.IRepository
{
    public interface IDefaultRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filterEntity = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string navigationProperties = null);

        TEntity Get(int id);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);

    }
}
