using Microsoft.EntityFrameworkCore;
using MyBookList.Services.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyBookList.Services.Repository
{
    public class DefaultRepository<T> : IDefaultRepository<T> where T : class
    {
        internal DbContext _dbContext;
        internal DbSet<T> _dbSet;
        public DefaultRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Delete(int id)
        {
            var result = _dbSet.Find(id);
            if(result != null)
            {
                _dbSet.Remove(result);
            }
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filterEntity = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string navigationProperties = null)
        {
            IQueryable<T> query = _dbSet;

            if (filterEntity != null)
            {
                query = query.Where(filterEntity);
            }

            if (navigationProperties != null)
            {
                foreach (var property in navigationProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(property);
                }
            }


            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }


            return query.ToList();

        }
    }
}
