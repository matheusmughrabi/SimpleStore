
using SimpleStore.ConsoleUI.Control.AuthenticationMenu;
using SimpleStore.ConsoleUI.Control.BeardStore;
using SimpleStore.ConsoleUI.Control.StoreTypesMenu;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;

namespace SimpleStore.ConsoleUI.Factories
{
    public static class MenuSimpleFactories
    {
        public static LoginMenu CreateLoginMenu(IUserLogger userLogger)
        {
            return new LoginMenu(userLogger);
        }

        public static RegisterMenu CreateRegisterMenu(IUserRegistrator userRegistrator)
        {
            return new RegisterMenu(userRegistrator);
        }

        public static MainMenu CreateMainMenu(IUserLogger userLogger)
        {
            return new MainMenu(userLogger);
        }

        public static BeardStoreCatalogMenu CreateBeardStoreCatalogMenu(AccountModel account)
        {
            return new BeardStoreCatalogMenu(account);
        }

        public static BeardStoreProductsMenu CreateBeardStoreProductsMenu(AccountModel account, CategoryModel category)
        {
            return new BeardStoreProductsMenu(account, category);
        }
    }
}
