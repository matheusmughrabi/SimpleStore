using SimpleStore.Domain.Manager.ManagerModels;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.AuthenticationServices
{
    public interface IManagerAuthenticationService
    {
        List<ManagerModel> GetRegisteredManagers();
    }
}
