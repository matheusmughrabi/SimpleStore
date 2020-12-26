using SimpleStore.Domain.UsersAuthenticator.UsersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Services.AuthenticationServices
{
    public interface IManagerAuthenticationService
    {
        List<ManagerModel> GetRegisteredManagers();
    }
}
