using SimpleStore.DataAccessLayer.Helpers;
using SimpleStore.Models.Models;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Models.Models;
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

        public List<ManagerAccount> GetRegisteredManagers()
        {
            List<ManagerAccount> registeredManagers = new List<ManagerAccount>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetManagers";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    ManagerAccount manager;

                    while (sqlDataReader.Read())
                    {
                        manager = new ManagerAccount();
                        manager.AccountOwner = new AccountOwner();
                        manager.ManagerPermission = new ManagerPermission();

                        manager.Id = sqlDataReader.GetInt32(0);
                        manager.AccountOwner.Id = sqlDataReader.GetInt32(1);
                        manager.AccountOwner.FirstName = sqlDataReader.GetString(2);
                        manager.AccountOwner.LastName = sqlDataReader.GetString(3);
                        manager.AccountOwner.Email = sqlDataReader.GetString(4);
                        manager.AccountOwner.Username = sqlDataReader.GetString(5);
                        manager.AccountOwner.Password = sqlDataReader.GetString(6);
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

        public List<ManagerAccount> GetUsersAndTitles()
        {
            List<ManagerAccount> registeredManagers = new List<ManagerAccount>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetUsersAndTitles";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    ManagerAccount manager;

                    while (sqlDataReader.Read())
                    {
                        manager = new ManagerAccount();
                        manager.AccountOwner = new AccountOwner();
                        manager.ManagerPermission = new ManagerPermission();

                        manager.AccountOwner.Id = sqlDataReader.GetInt32(0);
                        manager.AccountOwner.FirstName = sqlDataReader.GetString(1);
                        manager.AccountOwner.LastName = sqlDataReader.GetString(2);
                        manager.AccountOwner.Email = sqlDataReader.GetString(3);
                        manager.AccountOwner.Username = sqlDataReader.GetString(4);
                        manager.ManagerPermission.PermissionTitle = sqlDataReader.SafeGetString(5);

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

        public List<ManagerPermission> GetRegisteredManagerPermissions()
        {
            List<ManagerPermission> registeredManagerPermissions = new List<ManagerPermission>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetManagerPermissions";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    ManagerPermission managerPermission;

                    while (sqlDataReader.Read())
                    {
                        managerPermission = new ManagerPermission();

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

        public ManagerAccount CreateManager(ManagerAccount manager)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spCreateManager";

                _sqlCommand.Parameters.AddWithValue("@UserId", manager.AccountOwner.Id);
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
