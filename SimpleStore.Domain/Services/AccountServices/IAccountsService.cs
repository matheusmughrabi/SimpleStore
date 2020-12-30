using SimpleStore.Domain.UsersAccounts.AccountsModel;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.AccountServices
{
    public interface IAccountsService
    {
        List<AccountModel> GetAccounts();
        AccountModel GetAccountByUserId(int userId);
        AccountModel UpdateAccountBalanceByUserId(AccountModel account);
        bool CreateAccount(int UserId);
    }
}
