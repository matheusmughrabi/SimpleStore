using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Models.Models;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using System;
using System.Collections.Generic;
using SimpleStore.DataAccess.Data.Repository.IRepository;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class ManagerCreator : IManagerCreator
    {
        private readonly IUnityOfWork _unityOfWork;
        private IEnumerable<AccountOwner> _registeredUsers;
        private IEnumerable<AccountOwner> _registeredManagers;
        private IEnumerable<Roles> _registeredManagerPermissions;

        public ManagerCreator(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public bool RegisterManager(AccountOwner manager)
        {
            if (ManagerLogger.CurrentManager.Role.PermissionTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            _registeredUsers = _unityOfWork.AccountOwner.GetAll();

            _registeredManagerPermissions = _unityOfWork.Roles.GetAll();

            bool userExists = false;
            foreach (var registeredUser in _registeredUsers)
            {
                if (registeredUser.Username == manager.Username)
                {
                    manager.Id = registeredUser.Id;
                    userExists = true;
                    break;
                }
            }

            bool permissionExists = false;
            foreach (var registeredManagerPermission in _registeredManagerPermissions)
            {
                if (registeredManagerPermission.PermissionTitle == manager.Role.PermissionTitle)
                {
                    manager.Role.Id = registeredManagerPermission.Id;
                    permissionExists = true;
                    break;
                }
            }

            if (!userExists || !permissionExists)
            {
                return false;
            }

            Roles permission = _unityOfWork.Roles.GetFirstOrDefault(p => p.PermissionTitle == manager.Role.PermissionTitle);
            manager.RoleId = permission.Id;

            _unityOfWork.AccountOwner.UpdateRole(manager);
            _unityOfWork.Save();

            return true;
        }
    }
}
