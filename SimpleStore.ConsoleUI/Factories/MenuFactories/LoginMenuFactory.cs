using SimpleStore.ConsoleUI.Control.AuthenticationMenu;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenuFactories
{
    public class LoginMenuFactory
    {
        private IUserLogger _userLogger;

        public LoginMenuFactory(IUserLogger userLogger)
        {
            _userLogger = userLogger;
        }

        public LoginMenu CreateMenu()
        {
            return new LoginMenu(_userLogger);
        }
    }
}
