using SimpleStore.Domain.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services
{
    public abstract class BaseSqlServerService
    {
        protected IConnection _sqlServerConnection;
        protected SqlCommand _sqlCommand;

        public BaseSqlServerService(IConnection sqlServerConnection)
        {
            _sqlServerConnection = sqlServerConnection;
            _sqlCommand = _sqlServerConnection.GetSqlCommand();
        }
    }
}
