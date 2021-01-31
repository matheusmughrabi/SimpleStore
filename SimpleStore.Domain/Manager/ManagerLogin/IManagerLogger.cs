using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Manager.ManagerLogin
{
    public interface IManagerLogger
    {
        static ManagerAccount CurrentManager { get; }
        bool LoginManager(string username, string password);
        void LogoutManager();
    }
}
