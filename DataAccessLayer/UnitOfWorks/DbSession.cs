using System;
using System.Data;
using System.Data.Common;

namespace DataAccessLayer.UnitOfWorks
{
    public class DbSession : IDisposable
    {
        private Guid _id;
        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }
        private bool _disposed;
        
        public DbSession(DbConnection connection)
        {
            _id = Guid.NewGuid();
            Connection = connection;
            Connection.Open();
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
                    if (Connection != null)
                    {
                        Connection.Dispose();
                        Connection = null;
                    }
                }

                _disposed = true;
            }
        }

        ~DbSession()
        {
            Dispose(false);
        }
    }
}
