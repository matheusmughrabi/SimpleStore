using SimpleStore.Domain.Services;
using System.Data.SqlClient;

namespace SimpleStore.DataAccessLayer.Services
{
    public abstract class BaseSqlServerService
    {
        protected IConnection _sqlServerConnection;
        protected SqlCommand _sqlCommand;

        public BaseSqlServerService(IConnection sqlServerConnection)
        {
            _sqlServerConnection = sqlServerConnection;
            _sqlCommand = sqlServerConnection.GetSqlCommand();
        }
    }
}
