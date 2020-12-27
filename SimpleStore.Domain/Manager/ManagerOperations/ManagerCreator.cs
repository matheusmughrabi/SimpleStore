using SimpleStore.Domain.Manager.ManagerModels;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class ManagerCreator : IManagerCreator
    {
        private readonly IManagerService _managerService;
        private readonly IAuthenticationService _authenticationService;
        private List<UserModel> _registeredUsers;

        public ManagerCreator(IManagerService managerService, IAuthenticationService authenticationService)
        {
            _managerService = managerService;
            _authenticationService = authenticationService;
        }

        public bool RegisterManager(ManagerModel manager)
        {
            _registeredUsers = _authenticationService.GetRegisteredUsers();

            bool userExists = false;
            foreach (var registeredUser in _registeredUsers)
            {
                if (registeredUser.Username == manager.User.Username)
                {
                    manager.User.Id = registeredUser.Id;
                    userExists = true;
                }
            }

            if (!userExists)
            {
                return false;
            }

            _managerService.CreateManager(manager);
            return true;
        }
    }
}
