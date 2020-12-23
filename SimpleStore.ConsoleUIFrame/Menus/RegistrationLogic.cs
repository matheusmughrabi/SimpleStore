using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame.Menus
{
    public class RegistrationLogic
    {
        private IUserRegistrator _userRegistrator;
        private UserModel _userModel;

        public RegistrationLogic(IUserRegistrator userLogger, UserModel userModel)
        {
            _userRegistrator = userLogger;
            _userModel = userModel;
        }

        public bool Register(List<string> inputs)
        {
            _userModel.FirstName = inputs[0];
            _userModel.LastName = inputs[1];
            _userModel.Username = inputs[2];
            _userModel.Password = inputs[3];
            _userModel.ConfirmPassword = inputs[4];

            bool isLogginSuccessful = _userRegistrator.RegisterUser(_userModel);

            if (isLogginSuccessful)
            {
                Console.WriteLine("Registration successful");
            }
            else
            {
                Console.WriteLine("Registration failed");
            }

            Console.ReadLine();
            return isLogginSuccessful;
        }
    }
}
