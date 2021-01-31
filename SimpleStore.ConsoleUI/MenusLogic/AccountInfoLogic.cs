using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using System;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class AccountInfoLogic
    {
        private readonly AccountsLogic _accountLogic;

        public AccountInfoLogic(AccountsLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public void PrintAccountInfoLogic()
        {
            _accountLogic.ReloadCurrentAccount();
            Console.WriteLine($"{ _accountLogic.CurrentAccount.AccountOwner.FirstName } your balance is { _accountLogic.CurrentAccount.Balance }");
        }
    }
}
