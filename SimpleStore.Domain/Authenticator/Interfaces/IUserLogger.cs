using SimpleStore.Models.Models;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin
{
    public interface IUserLogger
    {
        static AccountOwner CurrentUser { get; }
        bool LoginUser(string username, string password);
        void Logout();
    }
}
