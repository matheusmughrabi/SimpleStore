using Microsoft.AspNet.Identity;
using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Models.Factories;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration
{
    public class UserRegistrator : IUserRegistrator
    {
        private readonly IUnityOfWork _unityOfWork;
        private static IPasswordHasher _passwordHasher = new PasswordHasher();
        private IEnumerable<AccountOwner> _registeredUsers;
        private AccountOwner _newAccountOwner;     

        public UserRegistrator(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public bool RegisterUser(AccountOwner newUser)
        {
            _registeredUsers = _unityOfWork.AccountOwner.GetAll();
            _newAccountOwner = newUser;
            _newAccountOwner.RoleId = 4;

            bool isLoginUnique = VerifyLogin();
            bool isEmailUnique = VerifyEmail();
            bool passwordsMatch = VerifyPasswordMatch();
            bool noNullOrEmptyData = CheckForNullData();

            if (!isLoginUnique || !isEmailUnique || !passwordsMatch || !noNullOrEmptyData)
            {
                return false;
            }

            _newAccountOwner.Password = _passwordHasher.HashPassword(_newAccountOwner.Password);

            _unityOfWork.AccountOwner.Add(_newAccountOwner);

            Account account = ModelsFactory.CreateAccountInstance();
            account.AccountOwner = _newAccountOwner;
            account.Balance = 0;

            _unityOfWork.Account.Add(account);

            _unityOfWork.Save();

            return true;
        }

        private bool VerifyLogin()
        {
            foreach (AccountOwner registeredUser in _registeredUsers)
            {
                if (registeredUser.Username == _newAccountOwner.Username)
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
                if (registeredUser.Email == _newAccountOwner.Email)
                {
                    return false;
                }
            }

            return true;
        }

        private bool VerifyPasswordMatch()
        {
            if (_newAccountOwner.Password != _newAccountOwner.ConfirmPassword)
            {
                return false;
            }

            return true;
        }

        private bool CheckForNullData()
        {
            if (string.IsNullOrEmpty(_newAccountOwner.FirstName) || string.IsNullOrEmpty(_newAccountOwner.LastName) || string.IsNullOrEmpty(_newAccountOwner.Username) ||
                string.IsNullOrEmpty(_newAccountOwner.Password))
            {
                return false;
            }
            return true;
        }
    }
}
