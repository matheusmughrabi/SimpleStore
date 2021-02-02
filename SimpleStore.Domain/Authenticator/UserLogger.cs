using Microsoft.AspNet.Identity;
using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Models.Factories;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin
{
    public class UserLogger : IUserLogger
    {
        private readonly IUnityOfWork _unityOfWork;
        private IPasswordHasher _passwordHasher;
        private IEnumerable<AccountOwner> _registeredUsers;
        private AccountOwner _accountOwner;
        public static Account CurrentAccount { get; private set; } = new Account(new AccountOwner());

        public UserLogger(IUnityOfWork unityOfWork)
        {
            _passwordHasher = new PasswordHasher();
            _unityOfWork = unityOfWork;
        }

        public bool LoginUser(string username, string password)
        {
            _registeredUsers = _unityOfWork.AccountOwner.GetAll();

            bool userExists = GetUser(username);
            bool isUsernamePasswordCorrect = false;

            if (userExists)
            {
                isUsernamePasswordCorrect = CheckPassword(password);

                if (isUsernamePasswordCorrect)
                {
                    CurrentAccount = _unityOfWork.Account.GetFirstOrDefault(a => a.AccountOwnerId == _accountOwner.Id);
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
                    _accountOwner = registeredUser;
                    return true;
                }
            }
            return false;
        }

        private bool CheckPassword(string password)
        {
            PasswordVerificationResult verifyPassword = _passwordHasher.VerifyHashedPassword(_accountOwner.Password, password);

            if (verifyPassword == PasswordVerificationResult.Success)
            {
                return true;
            }

            return false;
        }
    }
}
