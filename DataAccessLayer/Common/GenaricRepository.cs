using DataAccessLayer.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Common
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        public EntityDBContext Context;
        public DbSet<T> _dbSet;

        public GenaricRepository(EntityDBContext context)
        {
            this.Context = context;
            this._dbSet = context.Set<T>();
        }
        public void Delete(int id)
        {
            T EnntityDelete = _dbSet.Find(id);
            _dbSet.Remove(EnntityDelete);
        }

        public void Delete(T entityToDelete)
        {
            _dbSet.Remove(entityToDelete);
        }

        public IEnumerable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> filter = null, Func<System.Linq.IQueryable<T>, System.Linq.IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = this._dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(
                new char[] { ',' },
                StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
        }
    }
}
