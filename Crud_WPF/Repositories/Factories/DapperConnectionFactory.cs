using Crud_WPF.Factories.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;


namespace Crud_WPF.Factories
{
    public sealed class DapperConnectionFactory : IDapperConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public DapperConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;            
        }

        public SqlConnection Connection()
        {
            return new SqlConnection(_configuration.GetConnectionString("Connection"));
        }
    }
}
