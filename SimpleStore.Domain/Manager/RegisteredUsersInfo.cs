using SimpleStore.Models.Models;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
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

        public IEnumerable<AccountOwner> GetRegisteredUsers()
        {
            IEnumerable<AccountOwner> registeredUsersAndTitles = _unityOfWork.AccountOwner.GetAll(
                includeProperties : "Role");

            return registeredUsersAndTitles;
        }
    }
}
