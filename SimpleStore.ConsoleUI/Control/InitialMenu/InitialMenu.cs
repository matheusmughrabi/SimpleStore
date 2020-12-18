using SimpleStore.ConsoleUI.Control.AuthenticationMenu;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using System;

namespace SimpleStore.ConsoleUI.Control.InitialMenu
{
    public class InitialMenu : BaseMenu
    {
        private BaseMenu _authenticatorMenu;      
        private IUserLogger _userLogger;
        private IUserRegistrator _userRegistrator;
        private RootMenuFactory _rootMenuFactory;

        public InitialMenu(IUserLogger userLogger, IUserRegistrator userRegistrator, RootMenuFactory rootMenuFactory)
        {
            _userLogger = userLogger;
            _userRegistrator = userRegistrator;
            _rootMenuFactory = rootMenuFactory;
        }

        public override bool RunMenu()
        {
            DisplayInitialMenuMessages();
            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "0":
                    return false;
                case "1":
                    _authenticatorMenu = _rootMenuFactory.CreateMenu(MenuType.LoginMenu);
                    break;
                case "2":
                    _authenticatorMenu = _rootMenuFactory.CreateMenu(MenuType.RegisterMenu);
                    break;
                default:
                    DisplayInvalidOptionMessage();
                    return true;
            }

            bool sameAuthenticatorMenu = true;
            while (sameAuthenticatorMenu)
            {
                sameAuthenticatorMenu = _authenticatorMenu.RunMenu();
            }

            return true;
        }

        private void DisplayInitialMenuMessages()
        {
            Console.Clear();
            Console.WriteLine("1 - Login");
            Console.WriteLine("2 - Register");
            Console.WriteLine("0 - Exit program");
        }

        private void DisplayInvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }
    }
}
