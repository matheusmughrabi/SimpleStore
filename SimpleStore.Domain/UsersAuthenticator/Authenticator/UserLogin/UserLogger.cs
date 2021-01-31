using Microsoft.AspNet.Identity;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System.Collections.Generic;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin
{
    public class UserLogger : IUserLogger
    {
        private IAuthenticationService _authenticationService;
        private IAccountsService _accountsService;
        private IPasswordHasher _passwordHasher;
        private List<AccountOwner> _registeredUsers;
        private AccountOwner _user;
        public static AccountModel CurrentAccount { get; private set; } = new AccountModel(new AccountOwner());

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

        public void Logout()
        {
            CurrentAccount = null;
        }

        private bool GetUser(string username)
        {
            foreach (AccountOwner registeredUser in _registeredUsers)
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
