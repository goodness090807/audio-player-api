using System;

namespace DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
