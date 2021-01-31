using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Accounts.Interfaces
{
    public interface IAccountsLogic
    {
        Account CurrentAccount { get; }

        bool MakeDeposit(decimal amount);
        bool MakePurchase(decimal price);
        bool MakeWithdrawal(decimal amount);
        void ReloadCurrentAccount();
    }
}