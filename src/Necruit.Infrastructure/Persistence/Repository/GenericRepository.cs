using Microsoft.EntityFrameworkCore;
using Necruit.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Necruit.Infrastructure.Persistence.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : Entity
    {
        public DbContext Context;

        private DbSet<T> dbSet;

        public GenericRepository(DbContext context)
        {
            this.Context = context;
            this.dbSet = Context.Set<T>();
        }

        public virtual T FindById(object id)
        {
            return dbSet.Find(id);
        }

        public virtual IQueryable<T> All()
        {
            IQueryable<T> query = dbSet;
            return query;
        }

        public IQueryable<T> AllActives()
        {
            return FindBy(x => x.IsActive);
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> filter)
        {
            IQueryable<T> query = dbSet.Where(filter);
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

        public IQueryable<T> FindActivesBy(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}