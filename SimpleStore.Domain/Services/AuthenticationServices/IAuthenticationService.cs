using SimpleStore.Domain.UsersAuthenticator.Users;
using SimpleStore.Domain.UsersAuthenticator.UsersModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        List<UserModel> GetRegisteredUsers();

        UserModel RegisterNewUser(UserModel newUser);
    }
}
