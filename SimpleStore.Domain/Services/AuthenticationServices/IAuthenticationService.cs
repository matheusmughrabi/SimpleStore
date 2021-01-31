using SimpleStore.Domain.UsersAuthenticator.Users;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        List<AccountOwner> GetRegisteredUsers();

        AccountOwner RegisterUser(AccountOwner newUser);
    }
}
