using System;
using System.Linq;
using System.Linq.Expressions;

namespace Necruit.Infrastructure.Data.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(object id);

        IQueryable<T> All();

        IQueryable<T> GetBy(Expression<Func<T, bool>> filter);

        IQueryable<T> GetBy(Expression<Func<T, bool>> filter, string includeProperties);

        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        void Save();
    }
}
