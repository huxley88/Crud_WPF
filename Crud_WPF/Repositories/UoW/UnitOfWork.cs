using Crud_WPF.Factories.Interfaces;
using Crud_WPF.Interfaces;
using System.Data;

namespace Crud_WPF.UoW
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IDapperConnectionFactory _dapperConnectionFactory;
        private IDbConnection _connection = null;
        private IDbTransaction _transaction = null;

        public UnitOfWork(IDapperConnectionFactory dapperConnectionFactory)
        {
            _dapperConnectionFactory = dapperConnectionFactory;
            _connection = _dapperConnectionFactory.Connection();
        }

        IDbConnection IUnitOfWork.Connection => _connection;

        IDbTransaction IUnitOfWork.Transaction => _transaction;

        public void Begin()
        {
            if (_connection == null)
                IniciarConnection();

            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }

            if (_connection != null)
            {
                _connection.Dispose();
                _connection = null;
            }
        }

        private void IniciarConnection()
        {
            _connection = _dapperConnectionFactory.Connection();
        }
    }
}