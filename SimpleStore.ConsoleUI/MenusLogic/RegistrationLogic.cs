using SimpleStore.Domain.MailService;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class RegistrationLogic
    {
        private IUserRegistrator _userRegistrator;
        private AccountOwner _userModel;

        public RegistrationLogic(IUserRegistrator userLogger, AccountOwner userModel)
        {
            _userRegistrator = userLogger;
            _userModel = userModel;
        }

        public bool Register(List<string> inputs)
        {
            _userModel.FirstName = inputs[0];
            _userModel.LastName = inputs[1];
            _userModel.Email = inputs[2];
            _userModel.Username = inputs[3];
            _userModel.Password = inputs[4];
            _userModel.ConfirmPassword = inputs[5];

            bool isRegistrationSuccessful = _userRegistrator.RegisterUser(_userModel);

            if (isRegistrationSuccessful)
            {
                MailService.SendMail(_userModel.FirstName, _userModel.Email, "Registered at Simple Store", "You have successfuly registered to simple store");
                Console.WriteLine("Registration successful");
            }
            else
            {
                Console.WriteLine("Registration failed");
            }

            Console.ReadLine();
            return isRegistrationSuccessful;
        }
    }
}
