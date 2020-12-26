using SimpleStore.Domain.UsersAuthenticator.UsersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.ManagerLogin
{
    public interface IManagerLogger
    {
        static ManagerModel CurrentManager { get; }
        bool LoginManager(string username, string password);
    }
}
