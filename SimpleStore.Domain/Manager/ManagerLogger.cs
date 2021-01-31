using Microsoft.AspNet.Identity;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerLogin
{
    public class ManagerLogger : IManagerLogger
    {
        private IManagerService _managerAuthenticationService;
        private IPasswordHasher _passwordHasher;
        private List<ManagerAccount> _registeredManagers;
        private ManagerAccount _manager;
        public static ManagerAccount CurrentManager { get; private set; } = new ManagerAccount(new AccountOwner());

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

        public void LogoutManager()
        {
            CurrentManager = null;
        }

        private bool GetManager(string username)
        {
            foreach (ManagerAccount registeredManager in _registeredManagers)
            {
                if (username == registeredManager.AccountOwner.Username)
                {
                    _manager = registeredManager;
                    return true;
                }
            }
            return false;
        }

        private bool CheckPassword(string password)
        {
            PasswordVerificationResult verifyPassword = _passwordHasher.VerifyHashedPassword(_manager.AccountOwner.Password, password);

            if (verifyPassword == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
