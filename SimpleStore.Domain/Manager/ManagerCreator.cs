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
        private IEnumerable<Roles> _registeredRoles;

        public ManagerCreator(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public bool RegisterManager(AccountOwner manager)
        {
            if (ManagerLogger.CurrentManager.Role.RoleTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            _registeredUsers = _unityOfWork.AccountOwner.GetAll();

            _registeredRoles = _unityOfWork.Roles.GetAll();

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
            foreach (var role in _registeredRoles)
            {
                if (role.RoleTitle == manager.Role.RoleTitle)
                {
                    manager.Role.Id = role.Id;
                    permissionExists = true;
                    break;
                }
            }

            if (!userExists || !permissionExists)
            {
                return false;
            }

            Roles registeredRoles = _unityOfWork.Roles.GetFirstOrDefault(p => p.RoleTitle == manager.Role.RoleTitle);
            manager.RoleId = registeredRoles.Id;

            _unityOfWork.AccountOwner.UpdateRole(manager);
            _unityOfWork.Save();

            return true;
        }
    }
}
