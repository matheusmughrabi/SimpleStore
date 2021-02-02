using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Manager.ManagerOperations.Interfaces
{
    public interface IManagerCreator
    {
        bool RegisterManager(AccountOwner accountOwner);
    }
}
