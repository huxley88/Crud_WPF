using System.Data.SqlClient;

namespace Crud_WPF.Factories.Interfaces
{
    public interface IDapperConnectionFactory
    {
        SqlConnection Connection();
    }
}
