using SimpleStore.ConsoleUI.Factories.MenusFactories;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.AuthenticationMenu
{
    public class RegisterMenu : BaseMenu
    {
        private UserModel _newUser = new UserModel();
        private IUserRegistrator _userRegistrator;

        public RegisterMenu(IUserRegistrator userRegistrator)
        {
            _userRegistrator = userRegistrator;
        }

        public override bool RunMenu()
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

            DisplayRegisterMenuMessages();

            bool isRegistrationSuccessful;
            isRegistrationSuccessful = _userRegistrator.RegisterUser(_newUser);

            if (isRegistrationSuccessful)
            {
                SuccessfulRegistrationMessage();
                return false;
            }
            else
            {
                InvalidRegisterDataMessage();
                return true;
            }          
        }

        private void DisplayReturnPossibility()
        {
            Console.Clear();
            Console.WriteLine("This is the Register Menu, do you want to Register a new user or return to the Initial Menu");
            Console.WriteLine("1 - Proceed with Registration");
            Console.WriteLine("0 - Exit Register Menu");
        }

        public void DisplayRegisterMenuMessages()
        {
            Console.Clear();
            Console.WriteLine("Register new user here");

            Console.Write("Enter your First Name: ");
            _newUser.FirstName = Console.ReadLine();

            Console.Write("Enter your Last Name: ");
            _newUser.LastName = Console.ReadLine();

            Console.Write("Enter your Username: ");
            _newUser.Username = Console.ReadLine();

            Console.Write("Enter your Password: ");
            _newUser.Password = Console.ReadLine();

            Console.Write("Confirm your Password: ");
            _newUser.ConfirmPassword = Console.ReadLine();
        }

        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }

        public void InvalidRegisterDataMessage()
        {
            Console.WriteLine("Invalid register data, press 'Enter'to try again");
            Console.ReadLine();
        }

        public void SuccessfulRegistrationMessage()
        {
            Console.WriteLine("You are now successfuly registered! Press 'Enter' to go back to the Initial Menu'");
            Console.ReadLine();
        }
    }
}
