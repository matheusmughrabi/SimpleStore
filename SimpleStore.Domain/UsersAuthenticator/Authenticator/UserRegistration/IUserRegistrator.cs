using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration
{
    public interface IUserRegistrator
    {
        bool RegisterUser(UserModel newUser);
    }
}
