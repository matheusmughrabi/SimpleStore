using SimpleStore.Models.Models;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Services.AuthenticationServices;
using System.Collections.Generic;
using SimpleStore.DataAccess.Data.Repository.IRepository;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class RegisteredUsersInfo : IRegisteredUsersInfo
    {
        private readonly IUnityOfWork _unityOfWork;

        public RegisteredUsersInfo(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public IEnumerable<ManagerAccount> GetRegisteredUsers()
        {
            IEnumerable<ManagerAccount> registeredUsersAndTitles = _unityOfWork.Manager.GetAll(
                includeProperties : "AccountOwner,ManagerPermission");

            return registeredUsersAndTitles;
        }
    }
}
