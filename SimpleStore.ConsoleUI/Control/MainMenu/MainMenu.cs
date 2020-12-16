using SimpleStore.ConsoleUI.Control.ChooseStoreMenu;
using SimpleStore.ConsoleUI.Control.ProfileMenu;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;

namespace SimpleStore.ConsoleUI.Control.StoreTypesMenu
{
    public class MainMenu
    {
        private BaseSelectStoreMenu _chooseStoreMenu;
        private AccountMenu _accountMenu;
        private UserModel _currentUser;
        private AccountModel _account;

        public MainMenu(UserModel currentUser)
        {
            _currentUser = currentUser;
            GetAccount();
        }

        public bool RunStoreTypesMenu()

        {
            DisplayStoreTypeMessage();

            string chosenStoreType = Console.ReadLine();


            switch (chosenStoreType)
            {
                case "1":
                    _chooseStoreMenu = new SelectPizzaStoreMenu(_account);
                    break;
                case "2":
                    throw new NotImplementedException();
                case "0":
                    return false;
                case "01":
                    _accountMenu = new AccountMenu(_account);
                    bool continueInAccountMenu = true;
                    while (continueInAccountMenu)
                    {
                        continueInAccountMenu = _accountMenu.RunAccountMenu();
                    }
                    return true;
                default:
                    InvalidOptionMessage();
                    return true;
            }

            bool sameStoreType = true;
            while (sameStoreType)
            {
                sameStoreType = _chooseStoreMenu.RunMainMenu();
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
            Console.WriteLine("Choose a store type");
            Console.WriteLine("1 - Pizza Stores");
            Console.WriteLine("2 - Beard Products Stores");
            Console.WriteLine("01 - Check your account");
            Console.WriteLine("0 - Logout");
            
        }

        private void GetAccount()
        {
            IAccountsService accountService = ServicesSimpleFactory.CreateAccountsService();
            _account = accountService.GetAccountByUserId(_currentUser.Id);
        }
    }
}
