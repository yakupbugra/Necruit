using System;
using System.Linq;
using System.Linq.Expressions;

namespace Necruit.Infrastructure.Persistence.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        T FindById(object id);

        IQueryable<T> All();

        IQueryable<T> AllActives();

        IQueryable<T> FindBy(Expression<Func<T, bool>> filter);

        IQueryable<T> FindActivesBy(Expression<Func<T, bool>> filter);
        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        void Save();
    }
}