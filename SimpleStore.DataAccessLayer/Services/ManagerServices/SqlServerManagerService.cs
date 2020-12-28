using SimpleStore.Domain.Manager.ManagerModels;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleStore.DataAccessLayer.Services.ManagerServices
{
    public class SqlServerManagerService : BaseSqlServerService, IManagerService
    {
        public SqlServerManagerService(IConnection sqlServerConnection) : base(sqlServerConnection)
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
                        manager.ManagerPermission = new ManagerPermissionModel();

                        manager.Id = sqlDataReader.GetInt32(0);
                        manager.User.Id = sqlDataReader.GetInt32(1);
                        manager.User.FirstName = sqlDataReader.GetString(2);
                        manager.User.LastName = sqlDataReader.GetString(3);
                        manager.User.Email = sqlDataReader.GetString(4);
                        manager.User.Username = sqlDataReader.GetString(5);
                        manager.User.Password = sqlDataReader.GetString(6);
                        manager.ManagerPermission.PermissionTitle = sqlDataReader.GetString(7);

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

        public List<ManagerPermissionModel> GetRegisteredManagerPermissions()
        {
            List<ManagerPermissionModel> registeredManagerPermissions = new List<ManagerPermissionModel>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetManagerPermissions";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    ManagerPermissionModel managerPermission;

                    while (sqlDataReader.Read())
                    {
                        managerPermission = new ManagerPermissionModel();

                        managerPermission.Id = sqlDataReader.GetInt32(0);
                        managerPermission.PermissionTitle = sqlDataReader.GetString(1);

                        registeredManagerPermissions.Add(managerPermission);
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
            return registeredManagerPermissions;
        }

        public ManagerModel CreateManager(ManagerModel manager)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spCreateManager";

                _sqlCommand.Parameters.AddWithValue("@UserId", manager.User.Id);
                _sqlCommand.Parameters.AddWithValue("@ManagerPermissionId", manager.ManagerPermission.Id);
                _sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                _sqlServerConnection.OpenConnection();
                _sqlCommand.ExecuteNonQuery();

                manager.Id = Convert.ToInt32(_sqlCommand.Parameters["@Id"].Value);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _sqlServerConnection.CloseConnection();
            }

            return manager;
        }
    }
}
