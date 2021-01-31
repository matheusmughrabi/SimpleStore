using Dapper;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Models.Models;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;
using SimpleStore.Domain.Accounts.Interfaces;
using SimpleStore.DataAccess.Data.Repository.IRepository;

namespace SimpleStore.Domain.Accounts
{
    public class AccountsLogic : IAccountsLogic
    {
        private readonly IUnityOfWork _unityOfWork;
        public Account CurrentAccount { get; private set; }

        public AccountsLogic(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
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
                _unityOfWork.Account.UpdateBalance(CurrentAccount);

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
            //_accountsService.UpdateAccountBalanceByUserId(CurrentAccount);
            _unityOfWork.Account.UpdateBalance(CurrentAccount);

            return true;
        }

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
                //_accountsService.UpdateAccountBalanceByUserId(CurrentAccount);
                _unityOfWork.Account.UpdateBalance(CurrentAccount);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
