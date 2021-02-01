using Microsoft.AspNet.Identity;
using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerLogin
{
    public class ManagerLogger : IManagerLogger
    {
        private readonly IUnityOfWork _unityOfWork;
        private IPasswordHasher _passwordHasher;
        private IEnumerable<AccountOwner> _registeredManagers;
        private AccountOwner _manager;
        public static AccountOwner CurrentManager { get; private set; } = new AccountOwner();

        public ManagerLogger(IUnityOfWork unityOfWork)
        {
            _passwordHasher = new PasswordHasher();
            _unityOfWork = unityOfWork;
        }

        public bool LoginManager(string username, string password)
        {
            _registeredManagers = _unityOfWork.AccountOwner.GetAll(a => a.RoleId == 1 || a.RoleId == 2, null, includeProperties : "Role");

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
            foreach (var registeredManager in _registeredManagers)
            {
                if (username == registeredManager.Username)
                {
                    _manager = registeredManager;
                    return true;
                }
            }
            return false;
        }

        private bool CheckPassword(string password)
        {
            PasswordVerificationResult verifyPassword = _passwordHasher.VerifyHashedPassword(_manager.Password, password);

            if (verifyPassword == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
