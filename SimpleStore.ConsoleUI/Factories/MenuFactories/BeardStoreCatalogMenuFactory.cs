using SimpleStore.ConsoleUI.Control.BeardStore;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories.MenuFactories
{
    public class BeardStoreCatalogMenuFactory : IMenuFactory<BeardStoreCatalogMenu>
    {
        private readonly IUserLogger _userLogger;

        public BeardStoreCatalogMenuFactory(IUserLogger userLogger)
        {
            _userLogger = userLogger;
        }

        public BeardStoreCatalogMenu CreateMenu(RootMenuFactory rootMenuFactory)
        {
            return new BeardStoreCatalogMenu(rootMenuFactory, _userLogger);
        }
    }
}
