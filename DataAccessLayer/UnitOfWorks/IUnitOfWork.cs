﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DataAccessLayer.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
