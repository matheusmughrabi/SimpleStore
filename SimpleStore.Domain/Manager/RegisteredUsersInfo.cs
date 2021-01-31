using SimpleStore.Models.Models;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Services.AuthenticationServices;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class RegisteredUsersInfo : IRegisteredUsersInfo
    {
        private readonly IManagerService _managerService;

        public RegisteredUsersInfo(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public List<ManagerAccount> GetRegisteredUsers()
        {
            List<ManagerAccount> registeredUsersAndTitles = _managerService.GetUsersAndTitles();

            return registeredUsersAndTitles;
        }
    }
}
