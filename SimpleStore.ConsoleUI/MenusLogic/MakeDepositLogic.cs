﻿using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class MakeDepositLogic
    {
        private AccountsLogic _accountLogic;

        public MakeDepositLogic(AccountsLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public bool MakeDeposit(List<string> inputs)
        {
            decimal amount = 0;
            bool isValidAmount = decimal.TryParse(inputs[0], out amount);

            if (!isValidAmount)
            {
                Console.WriteLine("Invalid amount");
                Console.ReadLine();
                return false;
            }

            if (amount > 0)
            {
                _accountLogic.MakeDeposit(amount);
                Console.WriteLine("Deposit successful");
                Console.ReadLine();
            }

            return true;
        }
    }
}
