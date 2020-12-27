using SimpleStore.Domain.Manager.ManagerModels;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.AuthenticationServices
{
    public interface IManagerService
    {
        List<ManagerModel> GetRegisteredManagers();
        List<ManagerPermissionModel> GetRegisteredManagerPermissions();
        ManagerModel CreateManager(ManagerModel manager);
    }
}
