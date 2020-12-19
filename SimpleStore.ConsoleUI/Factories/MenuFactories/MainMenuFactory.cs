using SimpleStore.ConsoleUI.Control;
using SimpleStore.ConsoleUI.Control.StoreTypesMenu;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenuFactories
{
    public class MainMenuFactory : IMenuFactory<MainMenu>
    {
        private IUserLogger _userLogger;

        public MainMenuFactory(IUserLogger userLogger)
        {
            _userLogger = userLogger;
        }

        public MainMenu CreateMenu(RootMenuFactory rootMenuFactory)
        {
            throw new NotImplementedException();
        }
    }
}
