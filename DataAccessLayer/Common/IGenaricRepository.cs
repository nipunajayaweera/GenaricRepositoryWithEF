using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLayer.Common
{
    public interface IGenaricRepository<T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");
        T GetById(int id);

        void Insert(T entity);

        void Delete(int id);

        void Delete(T entityToDelete);

        void Update(T entityToUpdate);
    }
}
