using SimpleStore.ConsoleUI.Control.AuthenticationMenu;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenuFactories
{
    public class RegisterMenuFactory
    {
        private IUserRegistrator _userRegistrator;

        public RegisterMenuFactory(IUserRegistrator userRegistrator)
        {
            _userRegistrator = userRegistrator;
        }

        public RegisterMenu CreateMenu()
        {
            return new RegisterMenu(_userRegistrator);
        }
    }
}
