using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin
{
    public interface IUserLogger
    {
        static UserModel CurrentUser { get; }
        bool LoginUser(string username, string password);
        void Logout();
    }
}
