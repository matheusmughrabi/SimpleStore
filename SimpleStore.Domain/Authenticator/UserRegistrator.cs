using Microsoft.AspNet.Identity;
using SimpleStore.DataAccess.Data.Repository;
using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration
{
    public class UserRegistrator : IUserRegistrator
    {
        private static IPasswordHasher _passwordHasher = new PasswordHasher();
        private List<AccountOwner> _registeredUsers;
        private AccountOwner _newUser;
        private IAuthenticationService _authenticationService;
        private IAccountsService _accountsService;

        

        public UserRegistrator(IAuthenticationService authenticationService, IAccountsService accountsService)
        {
            _authenticationService = authenticationService;
            _accountsService = accountsService;
        }

        public bool RegisterUser(AccountOwner newUser)
        {
            _registeredUsers = _authenticationService.GetRegisteredUsers();
            _newUser = newUser;

            bool isLoginUnique = VerifyLogin();
            bool isEmailUnique = VerifyEmail();
            bool passwordsMatch = VerifyPasswordMatch();
            bool noNullOrEmptyData = CheckForNullData();

            if (!isLoginUnique || !isEmailUnique || !passwordsMatch || !noNullOrEmptyData)
            {
                return false;
            }

            newUser.Password = _passwordHasher.HashPassword(newUser.Password);
            //newUser = _authenticationService.RegisterUser(newUser);


            IUnityOfWork _unityOfWork = new UnityOfWork(new DataAccess.ApplicationDbContext());
            _unityOfWork.AccountOwner.Add(newUser);

            _unityOfWork.Save();

            _accountsService.CreateAccount(newUser.Id);

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
