using SimpleStore.ConsoleUIFrame.MenuFrame;
using SimpleStore.ConsoleUIFrame.Menus;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Users;

namespace SimpleStore.ConsoleUIFrame
{
    public class Application
    {
        private IUserLogger _userLogger;
        private IUserRegistrator _userRegistrator;
        private AccountsLogic _accountsLogic;

        public Application(IUserLogger userLogger, IUserRegistrator userRegistrator, AccountsLogic accountsLogic)
        {
            _userLogger = userLogger;
            _userRegistrator = userRegistrator;
            _accountsLogic = accountsLogic;
        }

        public void RunApp()
        {
            var initialMenu = new NavigatorMenu("Initial Menu", null);
            var loginMenu = new ActionMenu("Login Menu", initialMenu);
            var registerMenu = new ActionMenu("Register Menu", initialMenu);
            var mainMenu = new NavigatorMenu("Main Menu", loginMenu);
            var accountMenu = new NavigatorMenu("Account Menu", mainMenu);
            var makeDepositMenu = new ActionMenu("Make Deposit Menu", accountMenu);
            var makeWithdrawalMenu = new ActionMenu("Make Withdrawal Menu", accountMenu);
            var storeCategoriesMenu = new NavigatorMenu("Store Categories Menu", mainMenu);
            var storeProductsMenu = new ActionMenu("Store Products Menu", mainMenu);

            initialMenu.AddChildMenu(loginMenu);
            initialMenu.AddChildMenu(registerMenu);

            loginMenu.AddTextBox("Username");
            loginMenu.AddTextBox("Password");
            loginMenu.SetRenavigateMenu(mainMenu);
            loginMenu.Func = new LoginLogic(_userLogger).Login;

            registerMenu.AddTextBox("First Name");
            registerMenu.AddTextBox("Last Name");
            registerMenu.AddTextBox("Username");
            registerMenu.AddTextBox("Password");
            registerMenu.AddTextBox("Confirm Password");
            registerMenu.SetRenavigateMenu(initialMenu);
            registerMenu.Func = new RegistrationLogic(_userRegistrator, new UserModel()).Register;

            mainMenu.AddChildMenu(accountMenu);
            mainMenu.AddChildMenu(storeCategoriesMenu);
            mainMenu.AddTextBlock($"{ UserLogger.CurrentAccount.User.FirstName } your balance is { UserLogger.CurrentAccount.Balance }$");

            accountMenu.AddChildMenu(makeDepositMenu);
            accountMenu.AddChildMenu(makeWithdrawalMenu);

            makeDepositMenu.AddTextBox("Deposit Amount");
            makeDepositMenu.SetRenavigateMenu(accountMenu);
            makeDepositMenu.Func = new MakeDepositLogic(_accountsLogic).MakeDeposit;

            makeWithdrawalMenu.AddTextBox("Withdrawal Amount");
            makeWithdrawalMenu.SetRenavigateMenu(accountMenu);
            makeWithdrawalMenu.Func = new MakeWithdrawalLogic(_accountsLogic).MakeWithdrawal;

            storeCategoriesMenu.AddChildMenu(storeProductsMenu);

            initialMenu.Run();
        }
    }
}
