using SimpleStore.Domain.Accounts;
using SimpleStore.Domain.Accounts.Interfaces;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class MakeWithdrawalLogic
    {
        private IAccountsLogic _accountLogic;

        public MakeWithdrawalLogic(IAccountsLogic accountLogic)
        {
            _accountLogic = accountLogic;
        }

        public bool MakeWithdrawal(List<string> inputs)
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
                bool isWithdrawalSuccessful = _accountLogic.MakeWithdrawal(amount);
                if (isWithdrawalSuccessful)
                {
                    Console.WriteLine("Withdrawal successful");
                }
                else
                {
                    Console.WriteLine("Withdrawal unsuccessful");
                }
                Console.ReadLine();
            }

            return true;
        }
    }
}
