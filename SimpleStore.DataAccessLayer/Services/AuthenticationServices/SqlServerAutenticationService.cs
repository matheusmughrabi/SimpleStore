using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SimpleStore.DataAccessLayer.Services.AuthenticationServices
{
    public class SqlServerAutenticationService : BaseSqlServerService, IAuthenticationService
    {
        public SqlServerAutenticationService(IConnection sqlServerConnection) : base(sqlServerConnection) 
        {
        }

        public List<UserModel> GetRegisteredUsers()
        {
            List<UserModel> registeredUsers = new List<UserModel>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spGetUsers";

                _sqlServerConnection.OpenConnection();

                var sqlDataReader = _sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                {
                    UserModel user;

                    while (sqlDataReader.Read())
                    {
                        user = new UserModel();

                        user.Id = sqlDataReader.GetInt32(0);
                        user.FirstName = sqlDataReader.GetString(1);
                        user.LastName = sqlDataReader.GetString(2);
                        user.Username = sqlDataReader.GetString(3);
                        user.Password = sqlDataReader.GetString(4);

                        registeredUsers.Add(user);
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
            return registeredUsers;
        }

        public UserModel RegisterNewUser(UserModel newUser)
        {
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "spRegisterNewUser";

                _sqlCommand.Parameters.AddWithValue("@FirstName", newUser.FirstName);
                _sqlCommand.Parameters.AddWithValue("@LastName", newUser.LastName);
                _sqlCommand.Parameters.AddWithValue("@Username", newUser.Username);
                _sqlCommand.Parameters.AddWithValue("@HashedPassword", newUser.Password);
                _sqlCommand.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                _sqlServerConnection.OpenConnection();
                _sqlCommand.ExecuteNonQuery();

                newUser.Id = Convert.ToInt32(_sqlCommand.Parameters["@Id"].Value);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                _sqlServerConnection.CloseConnection();
            }

            return newUser;
        }
    }
}
