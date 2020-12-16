using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin
{
    public class UserLogger : IUserLogger
    {
        private IAuthenticationService _authenticationService;
        private IPasswordHasher _passwordHasher;
        private List<UserModel> _registeredUsers;
        private UserModel _user;
        public UserModel CurrentUser { get; private set; }

        public UserLogger(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
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
                    CurrentUser = _user;
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
