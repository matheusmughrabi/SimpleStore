using Microsoft.AspNet.Identity;
using SimpleStore.Domain.Manager.ManagerModels;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerLogin
{
    public class ManagerLogger : IManagerLogger
    {
        private IManagerService _managerAuthenticationService;
        private IPasswordHasher _passwordHasher;
        private List<ManagerModel> _registeredManagers;
        private ManagerModel _manager;
        public static ManagerModel CurrentManager { get; private set; } = new ManagerModel(new UserModel());

        public ManagerLogger(IManagerService managerAuthenticationService)
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
