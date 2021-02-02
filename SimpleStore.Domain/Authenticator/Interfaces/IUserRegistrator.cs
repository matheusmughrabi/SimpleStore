using SimpleStore.Models.Models;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration
{
    public interface IUserRegistrator
    {
        bool RegisterUser(AccountOwner accountOwner);
    }
}
