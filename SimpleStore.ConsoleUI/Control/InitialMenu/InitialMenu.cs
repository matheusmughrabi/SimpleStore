using SimpleStore.ConsoleUI.Control.AuthenticationMenu;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using System;

namespace SimpleStore.ConsoleUI.Control.InitialMenu
{
    public class InitialMenu
    {
        private BaseAuthenticatorMenu _authenticatorMenu;      
        private IUserLogger _userLogger;
        private IUserRegistrator _userRegistrator;

        public InitialMenu(IUserLogger userLogger, IUserRegistrator userRegistrator)
        {
            _userLogger = userLogger;
            _userRegistrator = userRegistrator;
        }

        public bool RunInitialMenu()
        {
            DisplayInitialMenuMessages();
            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "0":
                    return false;
                case "1":
                    _authenticatorMenu = new LoginMenu(_userLogger);
                    break;
                case "2":
                    _authenticatorMenu = new RegisterMenu(_userRegistrator);
                    break;
                default:
                    DisplayInvalidOptionMessage();
                    return true;
            }

            bool sameAuthenticatorMenu = true;
            while (sameAuthenticatorMenu)
            {
                sameAuthenticatorMenu = _authenticatorMenu.RunAuthenticatorMenu();
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
