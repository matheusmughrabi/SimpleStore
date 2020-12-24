using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.Services.AccountServices;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin
{
    public class UserLogger : IUserLogger
    {
        private IAuthenticationService _authenticationService;
        private IAccountsService _accountsService;
        private IPasswordHasher _passwordHasher;
        private List<UserModel> _registeredUsers;
        private UserModel _user;
        public static AccountModel CurrentAccount { get; private set; } = new AccountModel(new UserModel());

        public UserLogger(IAuthenticationService authenticationService, IAccountsService accountsService)
        {
            _authenticationService = authenticationService;
            _accountsService = accountsService;
            _passwordHasher = new PasswordHasher();
        }

        public bool LoginUser(string username, string password)
        {
            _registeredUsers = _authenticationService.GetRegisteredUsers();

            bool userExists = GetUser(username);
            bool isUsernamePasswordCorrect = false;

            if (userExists)
            {
                isUsernamePasswordCorrect = CheckPassword(password);

                if (isUsernamePasswordCorrect)
                {
                    CurrentAccount = _accountsService.GetAccountByUserId(_user.Id);
                }
            }

            return isUsernamePasswordCorrect;
        }

        private bool GetUser(string username)
        {
            foreach (UserModel registeredUser in _registeredUsers)
            {
                if (username == registeredUser.Username)
                {
                    _user = registeredUser;
                    return true;
                }
            }
            return false;
        }

        private bool CheckPassword(string password)
        {
            PasswordVerificationResult verifyPassword = _passwordHasher.VerifyHashedPassword(_user.Password, password);

            if (verifyPassword == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
