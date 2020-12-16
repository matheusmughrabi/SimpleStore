﻿using SimpleStore.ConsoleUI.Control.StoreTypesMenu;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;

namespace SimpleStore.ConsoleUI.Control.AuthenticationMenu
{
    public class LoginMenu : BaseAuthenticatorMenu
    {
        private UserModel _loginUser = new UserModel();
        private IUserLogger _userLogger;
        private MainMenu _mainMenu;
        private UserModel _currentUser;

        public LoginMenu(IUserLogger userLogger)
        {
            _userLogger = userLogger;
        }

        public override bool RunAuthenticatorMenu()
        {
            DisplayReturnPossibility();

            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "1":
                    break;
                case "0":
                    return false;
                default:
                    InvalidOptionMessage();
                    return true;
            }

            DisplayLoginMenuMessages();

            bool isLoginSuccessful = false;
            isLoginSuccessful = _userLogger.LoginUser(_loginUser.Username, _loginUser.Password);

            if (isLoginSuccessful)
            {
                _currentUser = _userLogger.CurrentUser;

                _mainMenu = new MainMenu(_currentUser);
                SuccessfulRegistrationMessage();

                bool stayLoggedIn = true;
                while (stayLoggedIn)
                {
                    stayLoggedIn = _mainMenu.RunStoreTypesMenu();
                }             
            }
            else
            {
                UnsuccessfulLogin();
            }
            
            return true;
        }

        private void DisplayLoginMenuMessages()
        {
            Console.Clear();
            Console.WriteLine("Login here");

            Console.Write("Enter your Username: ");
            _loginUser.Username = Console.ReadLine();

            Console.Write("Enter your Password: ");
            _loginUser.Password = Console.ReadLine();
        }

        private void DisplayReturnPossibility()
        {
            Console.Clear();
            Console.WriteLine("This is the Login Menu, do you want to Login or return to the Initial Menu");
            Console.WriteLine("1 - Proceed with Login");
            Console.WriteLine("0 - Exit Login Menu");
        }

        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }

        public void UnsuccessfulLogin()
        {
            Console.WriteLine("Login was not successful, press 'Enter'to try again");
            Console.ReadLine();
        }

        public void SuccessfulRegistrationMessage()
        {
            Console.WriteLine("You are now logged in! Press 'Enter' to go to the Main Menu'");
            Console.ReadLine();
        }
    }
}
