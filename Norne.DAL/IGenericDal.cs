
using System;
using System.Collections.Generic;

namespace Norne.DAL
{
    public interface IGenericDal<T> where T : class
    {
        IList<T> GetAll(params string[] includeProperties);
        IList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] includeProperties);
        T Add(T entity);
        T Attach(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
