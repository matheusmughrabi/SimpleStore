using Dapper;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace SimpleStore.DataAccessLayer.Services.AuthenticationServices
{
    public class SqliteAuthenticatorService : IAuthenticationService
    {
        public List<AccountOwner> GetRegisteredUsers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                IEnumerable<AccountOwner> output = cnn.Query<AccountOwner>("select * from Users", new DynamicParameters());
                return output.ToList();
            }
        }

        public AccountOwner RegisterUser(AccountOwner newUser)
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
