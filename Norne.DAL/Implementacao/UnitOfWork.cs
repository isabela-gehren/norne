using System;
using System.Data.Entity;

namespace Norne.DAL
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public UnitOfWork()
        {
            _dbContext = new NorneContext();

            var sqlProviderServices = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

        DbContext IUnitOfWork.DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            //Save changes with the default options
            return _dbContext.SaveChanges();
        }

        
        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

    }
}
