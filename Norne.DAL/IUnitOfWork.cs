
using System;
using System.Data.Entity;

namespace Norne.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DbContext { get; }

        int Commit();
    }
}
