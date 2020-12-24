using SimpleStore.MenuManager.MenuFrame;
using SimpleStore.MenuManager.Menus;
using System;
using System.Collections.Generic;

namespace SimpleStore.MenuManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var choicesInitialMenu = new List<MenuChoice>();
            var choicesLoginMenu = new List<MenuChoice>();
            var choicesRegisterMenu = new List<MenuChoice>();
            var choicesMainMenu = new List<MenuChoice>();

            string headerInitialMenu = "Initial Menu";
            string headerLoginMenu = "Login Menu";
            string headerRegisterMenu = "Register Menu";
            string headerMainMenu = "Main Menu";

            var menuInitial = new ConsoleMenu(headerInitialMenu, choicesInitialMenu, null);
            var menuLogin = new ConsoleMenu(headerLoginMenu, choicesLoginMenu, menuInitial);
            var menuRegister = new ConsoleMenu(headerRegisterMenu, choicesRegisterMenu, menuInitial);
            var menuMain = new ConsoleMenu(headerMainMenu, choicesMainMenu, menuLogin);

            choicesInitialMenu.Add(new MenuChoice(menuLogin.Header, new LoginLogic().Login));
            choicesInitialMenu.Add(new MenuChoice(menuRegister.Header, menuRegister.Run));

            choicesLoginMenu.Add(new MenuChoice(menuMain.Header, menuMain.Run));

            new MenuRunner(menuInitial).Run();
        }
    }
}
