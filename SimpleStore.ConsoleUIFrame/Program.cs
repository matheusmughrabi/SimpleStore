using SimpleStore.ConsoleUIFrame.BusinessLogic.Database;
using SimpleStore.ConsoleUIFrame.BusinessLogic.Login;
using SimpleStore.ConsoleUIFrame.MenuFrame;
using SimpleStore.ConsoleUIFrame.Menus;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUIFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            var initialMenu = new NavigatorMenu("Initial Menu", null);
            var loginMenu = new ActionMenu("Login Menu", initialMenu);
            var registerMenu = new ActionMenu("Register Menu", initialMenu);
            var mainMenu = new NavigatorMenu("Main Menu", loginMenu);
            var accountMenu = new NavigatorMenu("Account Menu", mainMenu);
            var makeDepositMenu = new ActionMenu("Make Deposit Menu", mainMenu);

            initialMenu.AddChildMenu(loginMenu);
            initialMenu.AddChildMenu(registerMenu);

            loginMenu.AddTextBox("username");
            loginMenu.SetRenavigateMenu(mainMenu);
            loginMenu.Func = new LoginLogic(new UserLogger(new AuthenticationService())).Login;

            registerMenu.AddTextBox("username");
            registerMenu.AddTextBox("password");

            mainMenu.AddChildMenu(accountMenu);

            accountMenu.AddChildMenu(makeDepositMenu);

            initialMenu.Run();
        }
    }
}
