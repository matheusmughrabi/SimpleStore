using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAccounts.AccountsModel
{
    public class AccountModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public decimal Balance { get; set; }
    }
}
