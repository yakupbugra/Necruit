using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Necruit.Infrastructure.Data.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public DbContext Context;

        private DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.dbSet = Context.Set<T>();
        }

        public virtual T GetById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> All()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public IQueryable<T> GetBy(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);
            return query;
        }

        public virtual IQueryable<T> GetBy(Expression<Func<T, bool>> filter, string includeProperties)
        {
            IQueryable<T> query = dbSet;
            query = query.Where(filter);

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public virtual void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(object id)
        {
            var entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }

        public virtual void Save()
        {
            Context.SaveChanges();
        }
    }
}
