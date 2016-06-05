
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Norne.DAL
{
    public abstract class GenericDal<T> : IGenericDal<T> where T : class
    {
        protected DbContext _context;
        protected IDbSet<T> _dbset;
        private IUnitOfWork _unit;
        protected IUnitOfWork Unit { get { return _unit; }  }
        public GenericDal(IUnitOfWork unit)
        {
            _context = unit.DbContext;
            _dbset = _context.Set<T>();
            _unit = unit;
        }

        public virtual IList<T> GetAll(params string[] includeProperties)
        {
            var query = GetQuery(includeProperties);
            return query.ToList<T>();
        }

        public IList<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] includeProperties)
        {
            var query = GetQuery(includeProperties);
            query = query.Where(predicate);
            return query.ToList<T>();
        }

        protected IQueryable<T> GetQuery(params string[] includeProperties)
        {
            var query = _dbset.AsQueryable<T>();

            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return query;
        }

        public virtual T Add(T entity)
        {
            return _dbset.Add(entity);
        }

        public virtual T Attach(T entity)
        {
            return _dbset.Attach(entity);
        }

        public virtual void Delete(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
        }

        public virtual void Update(T entity)
        {
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
        }
    }

}
