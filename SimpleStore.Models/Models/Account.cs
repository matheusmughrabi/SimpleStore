using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Account : DateTrackedModel
    {
        public AccountOwner AccountOwner { get; set; }
        public decimal Balance { get; set; }

        public Account()
        {

        }

        public Account(AccountOwner accountOwner)
        {
            AccountOwner = accountOwner;
        }       
    }
}
