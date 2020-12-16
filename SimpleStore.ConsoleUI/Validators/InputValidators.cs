using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.Validators
{
    public static class InputValidators
    {
        public static Tuple<bool, decimal> ValidatesAmount(string amountInput)
        {
            decimal amount;
            bool isValidInput = decimal.TryParse(amountInput, out amount);

            Tuple<bool, decimal> validationResult = new Tuple<bool, decimal>(isValidInput, amount);
            return validationResult;
        }
    }
}
