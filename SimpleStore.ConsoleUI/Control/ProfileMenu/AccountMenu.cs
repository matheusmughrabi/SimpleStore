using SimpleStore.ConsoleUI.Control.Validators;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.ProfileMenu
{
    public class AccountMenu : BaseMenu
    {
        private AccountModel _account;
        private AccountsLogic _accountLogic;

        public AccountMenu(AccountModel account)
        {
            _account = account;
            IAccountsService accountService = ServicesSimpleFactory.CreateAccountsService();
            _accountLogic = new AccountsLogic(_account, accountService);
        }

        public override bool RunMenu()
        {
            AccountMenuMessage();
            string selectedOption = Console.ReadLine();

            switch (selectedOption)
            {
                case "0":
                    return false;
                case "1":
                    MakeDeposit();
                    break;
                case "2":
                    MakeWithdrawal();
                    break;
                default:
                    InvalidOptionMessage();
                    return true;
            }

            return true;
        }

        private void AccountMenuMessage()
        {
            Console.Clear();
            Console.WriteLine("Choose amongst the following options");
            Console.WriteLine("1 - Make Deposit");
            Console.WriteLine("2 - Make Withdrawal");
            Console.WriteLine("0 - Exit");
        }

        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }

        private decimal ValidatesTransaction()
        {
            string amountInput = Console.ReadLine();
            var result = InputValidators.ValidatesAmount(amountInput);
            bool validInput = result.Item1;
            decimal amount = result.Item2;

            if (!validInput)
            {
                Console.WriteLine("Invalid amount, press 'Enter' to continue");
                Console.ReadLine();                
            }
            return amount;
        }

        private void MakeDeposit()
        {
            Console.Clear();
            Console.WriteLine("How much do you want to deposit?");

            decimal amount = ValidatesTransaction();

            if (amount > 0)
            {
                _accountLogic.MakeDeposit(amount);
            }         
        }

        private void MakeWithdrawal()
        {
            Console.Clear();
            Console.WriteLine("How much do you want to withdrawal?");

            
            decimal amount = ValidatesTransaction();

            bool success = false;
            if (amount > 0)
            {
                success = _accountLogic.MakeWithdrawal(amount);
            }
            else
            {
                return;
            }
            
            if (success)
            {
                Console.WriteLine("Withdrawal successful");
            }
            else
            {
                Console.WriteLine("Widthdrawal not successful");
            }

            Console.WriteLine("Press 'Enter' to continue");
            Console.ReadLine();
        }
    }
}

