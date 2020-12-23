using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleStore.Domain.UsersAccounts.AccountsLogic
{
    public class AccountsLogic
    {
        public AccountModel CurrentAccount { get; private set; }
        private IAccountsService _accountsService;

        public AccountsLogic(IAccountsService accountService)
        {
            _accountsService = accountService;
        }

        public bool MakePurchase(decimal price)
        {
            CurrentAccount = UserLogger.CurrentAccount;

            if (CurrentAccount.Balance >= price)
            {
                CurrentAccount.Balance -= price;
                _accountsService.UpdateAccountBalanceByUserId(CurrentAccount);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MakeDeposit(decimal amount)
        {
            CurrentAccount = UserLogger.CurrentAccount;

            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            CurrentAccount.Balance += amount;
            _accountsService.UpdateAccountBalanceByUserId(CurrentAccount);
            return true;
        }

        // TODO - Evaluate if this method is really necessary. Since it is the exact same as MakePurchase, it might be better to avoid the repetition, but I'm gonna leave it here for now in case I want to change its logic in the future without any impact in the places where MakePurchase is being used
        public bool MakeWithdrawal(decimal amount)
        {
            CurrentAccount = UserLogger.CurrentAccount;

            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            if (CurrentAccount.Balance >= amount)
            {
                CurrentAccount.Balance -= amount;
                _accountsService.UpdateAccountBalanceByUserId(CurrentAccount);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
