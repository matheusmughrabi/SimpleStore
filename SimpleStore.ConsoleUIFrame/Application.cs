using SimpleStore.ConsoleUIFrame.MenuFrame;
using SimpleStore.ConsoleUIFrame.Menus;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame
{
    public class Application
    {
        private IUserLogger _userLogger;

        public Application(IUserLogger userLogger)
        {
            _userLogger = userLogger;
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

            loginMenu.AddTextBox("username");
            loginMenu.AddTextBox("password");
            loginMenu.SetRenavigateMenu(mainMenu);
            loginMenu.Func = new LoginLogic(_userLogger).Login;

            registerMenu.AddTextBox("username");
            registerMenu.AddTextBox("password");

            mainMenu.AddChildMenu(accountMenu);
            mainMenu.AddChildMenu(storeCategoriesMenu);

            accountMenu.AddChildMenu(makeDepositMenu);
            accountMenu.AddChildMenu(makeWithdrawalMenu);

            storeCategoriesMenu.AddChildMenu(storeProductsMenu);

            initialMenu.Run();
        }
    }
}
