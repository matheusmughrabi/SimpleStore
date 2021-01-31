using Dapper;
using SimpleStore.Domain.IRepository;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;

namespace SimpleStore.Domain.UsersAccounts.AccountsLogic
{
    public class AccountsLogic
    {
        public AccountModel CurrentAccount { get; private set; }
        private IAccountsService _accountsService;
        private IRepositorySPCall _repository;

        public AccountsLogic(IAccountsService accountService, IRepositorySPCall repository)
        {
            _accountsService = accountService;
            _repository = repository;
        }

        public void ReloadCurrentAccount()
        {
            CurrentAccount = UserLogger.CurrentAccount;
        }

        public bool MakePurchase(decimal price)
        {
            CurrentAccount = UserLogger.CurrentAccount;

            if (CurrentAccount.Balance >= price)
            {
                CurrentAccount.Balance -= price;
                //_accountsService.UpdateAccountBalanceByUserId(CurrentAccount);

                var dictionary = new Dictionary<string, object>
                {
                    { "@UserId", CurrentAccount.AccountOwner.Id},
                    { "@Balance", CurrentAccount.Balance}
                };

                DynamicParameters parameters = new DynamicParameters(dictionary);
                _repository.ExecuteWithoutReturn("spUpdateAccountBalance", parameters);
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
