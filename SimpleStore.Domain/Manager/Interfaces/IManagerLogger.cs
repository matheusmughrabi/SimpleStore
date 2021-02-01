using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Manager.ManagerLogin
{
    public interface IManagerLogger
    {
        static AccountOwner CurrentManager { get; }
        bool LoginManager(string username, string password);
        void LogoutManager();
    }
}
