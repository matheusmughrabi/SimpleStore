using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class RegisteredUsersInfo : IRegisteredUsersInfo
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisteredUsersInfo(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public List<UserModel> GetRegisteredUsers()
        {
            List<UserModel> registeredUsers = _authenticationService.GetRegisteredUsers();
            return registeredUsers;
        }
    }
}
