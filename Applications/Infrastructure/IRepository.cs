using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Infrastructure
{
    public interface IRepository<T, K> : IDisposable where T : class
    {
        T FindById(K id, params Expression<Func<T, object>>[] includeProperties);
        IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties);
        IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties);

        void Add(T entity);
        void Remove(T entity);
        void Remove(K id);
    }
}
