using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerOperations.Interfaces
{
    public interface IRegisteredUsersInfo
    {
        IEnumerable<ManagerAccount> GetRegisteredUsers();
    }
}
