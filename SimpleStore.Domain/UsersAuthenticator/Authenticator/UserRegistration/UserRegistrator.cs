using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Users;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration
{
    public class UserRegistrator : IUserRegistrator
    {
        private static IPasswordHasher _passwordHasher = new PasswordHasher();
        private List<UserModel> _registeredUsers;
        private UserModel _newUser;
        private IAuthenticationService _authenticationService;
        private IAccountsService _accountsService;

        public UserRegistrator(IAuthenticationService authenticationService, IAccountsService accountsService)
        {
            _authenticationService = authenticationService;
            _accountsService = accountsService;
        }

        public bool RegisterUser(UserModel newUser)
        {
            _registeredUsers = _authenticationService.GetRegisteredUsers();
            _newUser = newUser;           

            bool isUniqueLogin = VerifyLogin();
            bool passwordsMatch = VerifyPasswordMatch();
            bool noNullOrEmptyData = CheckForNullData();

            if (!isUniqueLogin || !passwordsMatch || !noNullOrEmptyData)
            {
                return false;
            }

            newUser.Password = _passwordHasher.HashPassword(newUser.Password);
            newUser = _authenticationService.RegisterNewUser(newUser);
            _accountsService.CreateAccount(newUser.Id);
            return true;
        }

        private bool VerifyLogin()
        {
            foreach (UserModel registeredUser in _registeredUsers)
            {
                if (registeredUser.Username == _newUser.Username)
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyPasswordMatch()
        {
            if (_newUser.Password != _newUser.ConfirmPassword)
            {
                return false;
            }

            return true;
        }

        private bool CheckForNullData()
        {
            if (string.IsNullOrEmpty(_newUser.FirstName) || string.IsNullOrEmpty(_newUser.LastName) || string.IsNullOrEmpty(_newUser.Username) || 
                string.IsNullOrEmpty(_newUser.Password))
            {
                return false;
            }
            return true;
        }
    }
}
