using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        List<AccountOwner> GetRegisteredUsers();

        AccountOwner RegisterUser(AccountOwner newUser);
    }
}
