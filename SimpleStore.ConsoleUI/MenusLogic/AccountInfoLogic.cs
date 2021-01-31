using SimpleStore.Domain.Accounts;
using SimpleStore.Domain.Accounts.Interfaces;
using System;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class AccountInfoLogic
    {
        private readonly IAccountsLogic _accountLogic;

        public AccountInfoLogic(IAccountsLogic accountLogic)
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
