using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.AccountServices
{
    public interface IAccountsService
    {
        List<Account> GetAccounts();
        Account GetAccountByUserId(int userId);
        Account UpdateAccountBalanceByUserId(Account account);
        bool CreateAccount(int UserId);
    }
}
