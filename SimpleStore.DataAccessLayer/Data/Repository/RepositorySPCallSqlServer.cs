using Dapper;
using SimpleStore.Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Data.Repository
{
    public class RepositorySPCallSqlServer : IRepositorySPCall
    {
        private readonly string _connectionString = ConfigurationManager.ConnectionStrings["sqlServerExtFactory"].ConnectionString;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> ExecuteReturnList<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();

                IEnumerable<T> scalerList = sqlConn.Query<T>(procedureName, param, commandType: CommandType.StoredProcedure);

                return scalerList;
            }
        }

        public T ExecuteReturnScaler<T>(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();

                T scaler = (T)Convert.ChangeType(sqlConn.ExecuteScalar<T>(procedureName, param, commandType: CommandType.StoredProcedure), typeof(T));

                return scaler;
            }
        }

        public void ExecuteWithoutReturn(string procedureName, DynamicParameters param = null)
        {
            using (SqlConnection sqlConn = new SqlConnection(_connectionString))
            {
                sqlConn.Open();

                sqlConn.Execute(procedureName, param, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
