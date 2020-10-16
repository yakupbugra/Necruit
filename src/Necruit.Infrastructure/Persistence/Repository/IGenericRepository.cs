using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Necruit.Infrastructure.Persistence.Repository
{
    public interface IGenericRepository<T>
    {
        T FindById(object id);

        IQueryable<T> All();

        IQueryable<T> AllActives();

        IQueryable<T> AllPassives();

        IQueryable<T> FindBy(Expression<Func<T, bool>> filter);

        IQueryable<T> FindActivesBy(Expression<Func<T, bool>> filter);

        void Add(T entity);

        void Update(T entity);

        void Delete(object id);

        void Save();

        Task SaveAsync();
    }
}