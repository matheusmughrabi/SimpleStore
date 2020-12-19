using SimpleStore.ConsoleUI.Control.AuthenticationMenu;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenuFactories
{
    public class RegisterMenuFactory : IMenuFactory<RegisterMenu>
    {
        private IUserRegistrator _userRegistrator;

        public RegisterMenuFactory(IUserRegistrator userRegistrator)
        {
            _userRegistrator = userRegistrator;
        }

        public RegisterMenu CreateMenu(RootMenuFactory rootMenuFactory)
        {
            throw new NotImplementedException();
        }
    }
}
