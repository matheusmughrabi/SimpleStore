using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.AuthenticationServices
{
    public interface IManagerService
    {
        List<ManagerAccount> GetRegisteredManagers();
        List<ManagerAccount> GetUsersAndTitles();
        List<ManagerPermission> GetRegisteredManagerPermissions();
        ManagerAccount CreateManager(ManagerAccount manager);
    }
}
