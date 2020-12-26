using Microsoft.AspNet.Identity;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using SimpleStore.Domain.UsersAuthenticator.UsersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.ManagerLogin
{
    public class ManagerLogger : IManagerLogger
    {
        private IManagerAuthenticationService _managerAuthenticationService;
        private IPasswordHasher _passwordHasher;
        private List<ManagerModel> _registeredManagers;
        private ManagerModel _manager;
        public static ManagerModel CurrentManager { get; private set; } = new ManagerModel(new UserModel());

        public ManagerLogger(IManagerAuthenticationService managerAuthenticationService)
        {
            _managerAuthenticationService = managerAuthenticationService;
            _passwordHasher = new PasswordHasher();
        }

        public bool LoginManager(string username, string password)
        {
            _registeredManagers = _managerAuthenticationService.GetRegisteredManagers();

            bool userExists = GetManager(username);
            bool isUsernamePasswordCorrect = false;

            if (userExists)
            {
                isUsernamePasswordCorrect = CheckPassword(password);

                if (isUsernamePasswordCorrect)
                {
                    CurrentManager = _manager;
                }
            }

            return isUsernamePasswordCorrect;
        }

        private bool GetManager(string username)
        {
            foreach (ManagerModel registeredManager in _registeredManagers)
            {
                if (username == registeredManager.User.Username)
                {
                    _manager = registeredManager;
                    return true;
                }
            }
            return false;
        }

        private bool CheckPassword(string password)
        {
            PasswordVerificationResult verifyPassword = _passwordHasher.VerifyHashedPassword(_manager.User.Password, password);

            if (verifyPassword == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
