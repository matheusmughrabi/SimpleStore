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
        private AccountModel _account;
        private IAccountsService _accountsService;

        public AccountsLogic(IAccountsService accountService)
        {
            _accountsService = accountService;
        }

        public bool MakePurchase(decimal price)
        {
            _account = UserLogger.CurrentAccount;

            if (_account.Balance >= price)
            {
                _account.Balance -= price;
                _accountsService.UpdateAccountBalanceByUserId(_account);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MakeDeposit(decimal amount)
        {
            _account = UserLogger.CurrentAccount;

            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            _account.Balance += amount;
            _accountsService.UpdateAccountBalanceByUserId(_account);
            return true;
        }

        // TODO - Evaluate if this method is really necessary. Since it is the exact same as MakePurchase, it might be better to avoid the repetition, but I'm gonna leave it here for now in case I want to change its logic in the future without any impact in the places where MakePurchase is being used
        public bool MakeWithdrawal(decimal amount)
        {
            _account = UserLogger.CurrentAccount;

            if (amount < 0)
            {
                throw new ArgumentException("Amount must be positive");
            }

            if (_account.Balance >= amount)
            {
                _account.Balance -= amount;
                _accountsService.UpdateAccountBalanceByUserId(_account);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
