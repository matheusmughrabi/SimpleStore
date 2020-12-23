using SimpleStore.ConsoleUIFrame.BusinessLogic.Database;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame.BusinessLogic.Login
{
    public class UserLogger : IUserLogger
    {
        private IAuthenticationService _authenticationService;
        private string _user;
        private List<string> _registeredUsers;
        public string CurrentUser { get; private set; }

        public UserLogger(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public bool LoginUser(string username)
        {
            _registeredUsers = _authenticationService.GetRegisteredUsers();

            bool userExists = GetUser(username);

            if (userExists)
            {
                return true;
            }

            return false;
        }

        private bool GetUser(string username)
        {
            foreach (string registeredUser in _registeredUsers)
            {
                if (username == registeredUser)
                {
                    _user = registeredUser;
                    return true;
                }
            }
            return false;
        }
    }
}
