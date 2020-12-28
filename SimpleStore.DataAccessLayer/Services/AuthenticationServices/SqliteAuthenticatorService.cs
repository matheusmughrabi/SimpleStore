using Dapper;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;

namespace SimpleStore.DataAccessLayer.Services.AuthenticationServices
{
    public class SqliteAuthenticatorService : IAuthenticationService
    {
        public List<UserModel> GetRegisteredUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                IEnumerable<UserModel> output = cnn.Query<UserModel>("select * from Users", new DynamicParameters());
                return output.ToList();
            }
        }

        public UserModel RegisterUser(UserModel newUser)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Users (FirstName, LastName, Username, Password) values (@FirstName, @LastName, @Username, @Password)", newUser);
            }

            return newUser;
        }

        private static string LoadConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["sqliteExtFactory"].ConnectionString;
        }
    }
}
