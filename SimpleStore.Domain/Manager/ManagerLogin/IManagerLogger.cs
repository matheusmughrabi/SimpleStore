using SimpleStore.Domain.Manager.ManagerModels;

namespace SimpleStore.Domain.Manager.ManagerLogin
{
    public interface IManagerLogger
    {
        static ManagerModel CurrentManager { get; }
        bool LoginManager(string username, string password);
    }
}
