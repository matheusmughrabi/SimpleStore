using SimpleStore.Domain.Manager.ManagerModels;

namespace SimpleStore.Domain.Manager.ManagerOperations.Interfaces
{
    public interface IManagerCreator
    {
        bool RegisterManager(ManagerModel manager);
    }
}
