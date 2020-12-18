using SimpleStore.ConsoleUI.Control;
using SimpleStore.ConsoleUI.Control.StoreTypesMenu;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenuFactories
{
    public class MainMenuFactory : IMenuFactory<MainMenu>
    {
        private UserModel _currentUser;

        public MainMenuFactory(UserModel currentUser)
        {
            _currentUser = currentUser;
        }

        public MainMenu CreateMenu(RootMenuFactory rootMenuFactory)
        {
            return new MainMenu(rootMenuFactory, _currentUser);
        }
    }
}
