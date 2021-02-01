using Microsoft.AspNet.Identity;
using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration
{
    public class UserRegistrator : IUserRegistrator
    {
        private readonly IUnityOfWork _unityOfWork;
        private static IPasswordHasher _passwordHasher = new PasswordHasher();
        private IEnumerable<AccountOwner> _registeredUsers;
        private AccountOwner _newUser;     

        public UserRegistrator(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public bool RegisterUser(AccountOwner newUser)
        {
            _registeredUsers = _unityOfWork.AccountOwner.GetAll();
            _newUser = newUser;
            _newUser.RoleId = 4;

            bool isLoginUnique = VerifyLogin();
            bool isEmailUnique = VerifyEmail();
            bool passwordsMatch = VerifyPasswordMatch();
            bool noNullOrEmptyData = CheckForNullData();

            if (!isLoginUnique || !isEmailUnique || !passwordsMatch || !noNullOrEmptyData)
            {
                return false;
            }

            _newUser.Password = _passwordHasher.HashPassword(_newUser.Password);

            _unityOfWork.AccountOwner.Add(_newUser);

            Account account = new Account();
            account.AccountOwner = _newUser;
            account.Balance = 0;

            _unityOfWork.Account.Add(account);

            _unityOfWork.Save();

            return true;
        }

        private bool VerifyLogin()
        {
            foreach (AccountOwner registeredUser in _registeredUsers)
            {
                if (registeredUser.Username == _newUser.Username)
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyEmail()
        {
            foreach (AccountOwner registeredUser in _registeredUsers)
            {
                if (registeredUser.Email == _newUser.Email)
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
