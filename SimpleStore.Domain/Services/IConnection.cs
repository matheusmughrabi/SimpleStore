using System.Data.SqlClient;

namespace SimpleStore.Domain.Services
{
    public interface IConnection
    {
        void GetConnection();
        void OpenConnection();
        void CloseConnection();
        SqlCommand GetSqlCommand();
    }
}
