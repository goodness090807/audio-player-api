using System;

namespace DataAccessLayer.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbSession _dbSession;
        private bool _disposed;

        public UnitOfWork(DbSession dbSession)
        {
            _dbSession = dbSession;
        }

        public void BeginTransaction()
        {
            _dbSession.Transaction = _dbSession.Connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _dbSession.Transaction.Commit();
            }
            catch
            {
                _dbSession.Transaction.Rollback();
                throw;
            }
            finally
            {
                _dbSession.Transaction.Dispose();
            }
        }

        public void Rollback()
        {
            _dbSession.Transaction.Rollback();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_dbSession.Transaction != null)
                    {
                        _dbSession.Transaction.Dispose();
                        _dbSession.Transaction = null;
                    }
                }
                
                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
