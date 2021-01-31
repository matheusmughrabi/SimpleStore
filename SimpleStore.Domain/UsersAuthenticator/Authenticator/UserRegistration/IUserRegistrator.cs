using SimpleStore.Domain.UsersAuthenticator.Users;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration
{
    public interface IUserRegistrator
    {
        bool RegisterUser(AccountOwner newUser);
    }
}
