using SimpleStore.Domain.Services;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SimpleStore.DataAccessLayer.Connections
{
    public class SqlServerConnection : IConnection
    {
        private SqlConnection _sqlConnection;
        private SqlCommand _sqlCommand;

        public SqlServerConnection()
        {
            GetConnection();
        }

        public void GetConnection()
        {
            string stringConexao = ConfigurationManager.ConnectionStrings["sqlServerExtFactory"].ConnectionString;
            _sqlConnection = new SqlConnection(stringConexao);
        }

        public void OpenConnection()
        {
            _sqlConnection.Open();
        }

        public void CloseConnection()
        {
            _sqlConnection.Close();
        }

        public SqlCommand GetSqlCommand()
        {
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
            _sqlCommand.CommandType = CommandType.StoredProcedure;

            return _sqlCommand;
        }
    }
}
