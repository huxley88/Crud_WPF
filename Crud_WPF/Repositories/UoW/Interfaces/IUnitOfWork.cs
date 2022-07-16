using System;
using System.Data;

namespace Crud_WPF.Interfaces
{
    public interface IUnitOfWork
    {        
        IDbConnection Connection { get; }
        IDbTransaction Transaction { get; }        
        void Begin();
        void Commit();
        void Rollback();
    }
}
