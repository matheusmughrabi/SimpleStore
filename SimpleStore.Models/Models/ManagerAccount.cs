using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class ManagerAccount : BaseModel
    {
        public AccountOwner AccountOwner { get; set; }
        public ManagerPermission ManagerPermission { get; set; }

        public ManagerAccount()
        {

        }
        public ManagerAccount(AccountOwner accountOwner)
        {
            AccountOwner = accountOwner;
        }
    }
}
