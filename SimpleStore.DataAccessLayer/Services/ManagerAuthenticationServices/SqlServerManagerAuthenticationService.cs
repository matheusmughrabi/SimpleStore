using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using SimpleStore.Domain.UsersAuthenticator.UsersModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.ManagerAuthenticationServices
{
    public class SqlServerManagerAuthenticationService : BaseSqlServerService, IManagerAuthenticationService
    {
        public SqlServerManagerAuthenticationService(IConnection sqlServerConnection) : base(sqlServerConnection)
        {
        }

        public List<ManagerModel> GetRegisteredManagers()
        {
            List<ManagerModel> registeredManagers = new List<ManagerModel>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetManagers";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    ManagerModel manager;

                    while (sqlDataReader.Read())
                    {
                        manager = new ManagerModel();
                        manager.User = new UserModel();

                        manager.Id = sqlDataReader.GetInt32(0);
                        manager.User.Id = sqlDataReader.GetInt32(1);
                        manager.User.FirstName = sqlDataReader.GetString(2);
                        manager.User.LastName = sqlDataReader.GetString(3);
                        manager.User.Username = sqlDataReader.GetString(4);
                        manager.User.Password = sqlDataReader.GetString(5);
                        manager.ManagerPermission = sqlDataReader.GetString(6);

                        registeredManagers.Add(manager);
                    }
                }
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                _sqlServerConnection.CloseConnection();
            }
            return registeredManagers;
        }
    }
}
