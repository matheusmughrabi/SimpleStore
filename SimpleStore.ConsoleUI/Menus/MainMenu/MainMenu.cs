using SimpleStore.ConsoleUI.Control.ProfileMenu;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;

namespace SimpleStore.ConsoleUI.Control.StoreTypesMenu
{
    public class MainMenu : BaseMenu
    {
        private BaseMenu _beardStoreCatalogMenu;
        private AccountMenu _accountMenu;
        private UserModel _currentUser;
        private AccountModel _account;

        public MainMenu(IUserLogger userLogger)
        {
            _currentUser = userLogger.CurrentUser;
            GetAccount();
        }

        public override bool RunMenu()
        {
            DisplayStoreTypeMessage();

            string chosenStoreType = Console.ReadLine();


            switch (chosenStoreType)
            {
                case "1":
                    _beardStoreCatalogMenu = MenuSimpleFactories.CreateBeardStoreCatalogMenu(_account);
                    break;
                case "2":
                    _accountMenu = new AccountMenu(_account);
                    bool continueInAccountMenu = true;
                    while (continueInAccountMenu)
                    {
                        continueInAccountMenu = _accountMenu.RunMenu();
                    }
                    return true;
                case "0":
                    return false;                    
                default:
                    InvalidOptionMessage();
                    return true;
            }

            bool sameStoreType = true;
            while (sameStoreType)
            {
                sameStoreType = _beardStoreCatalogMenu.RunMenu();
            }
            
            return true;
        }

        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }

        private void DisplayStoreTypeMessage()
        {
            Console.Clear();
            Console.WriteLine($"Hello { _account.User.FullName }, your balance is { _account.Balance }");
            Console.WriteLine("Choose an option");
            Console.WriteLine("1 - Check Beard Store catalog");
            Console.WriteLine("2 - Check your account");
            Console.WriteLine("0 - Logout");
            
        }

        private void GetAccount()
        {
            IAccountsService accountService = ServicesSimpleFactory.CreateAccountsService();
            _account = accountService.GetAccountByUserId(_currentUser.Id);
        }
    }
}
