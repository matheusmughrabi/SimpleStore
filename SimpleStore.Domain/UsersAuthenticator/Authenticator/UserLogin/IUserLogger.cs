using SimpleStore.Domain.UsersAuthenticator.Users;

namespace SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin
{
    public interface IUserLogger
    {
        static UserModel CurrentUser { get; }
        bool LoginUser(string username, string password);
        void Logout();
    }
}
