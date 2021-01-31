using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Models.Models;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Services.AuthenticationServices;
using System;
using System.Collections.Generic;
using SimpleStore.DataAccess.Data.Repository.IRepository;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class ManagerCreator : IManagerCreator
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IManagerService _managerService;
        private IEnumerable<AccountOwner> _registeredUsers;
        private List<ManagerAccount> _registeredManagers;
        private List<ManagerPermission> _registeredManagerPermissions;

        public ManagerCreator(IManagerService managerService, IUnityOfWork unityOfWork)
        {
            _managerService = managerService;
            _unityOfWork = unityOfWork;
        }

        public bool RegisterManager(ManagerAccount manager)
        {
            if (ManagerLogger.CurrentManager.ManagerPermission.PermissionTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            //_registeredUsers = _authenticationService.GetRegisteredUsers();
            _registeredUsers = _unityOfWork.AccountOwner.GetAll();

            _registeredManagerPermissions = _managerService.GetRegisteredManagerPermissions();
            _registeredManagers = _managerService.GetRegisteredManagers();

            bool userExists = false;
            foreach (var registeredUser in _registeredUsers)
            {
                if (registeredUser.Username == manager.AccountOwner.Username)
                {
                    manager.AccountOwner.Id = registeredUser.Id;
                    userExists = true;
                    break;
                }
            }

            bool permissionExists = false;
            foreach (var registeredManagerPermission in _registeredManagerPermissions)
            {
                if (registeredManagerPermission.PermissionTitle == manager.ManagerPermission.PermissionTitle)
                {
                    manager.ManagerPermission.Id = registeredManagerPermission.Id;
                    permissionExists = true;
                    break;
                }
            }

            if (!userExists || !permissionExists)
            {
                return false;
            }

            foreach (var registeredManger in _registeredManagers)
            {
                if (registeredManger.AccountOwner.Username == manager.AccountOwner.Username)
                {
                    return false;
                }
            }

            _managerService.CreateManager(manager);
            return true;
        }
    }
}
