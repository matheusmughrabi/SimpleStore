using SimpleStore.Domain.Manager.ManagerModels;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerOperations.Interfaces
{
    public interface IRegisteredUsersInfo
    {
        List<ManagerModel> GetRegisteredUsers();
    }
}
