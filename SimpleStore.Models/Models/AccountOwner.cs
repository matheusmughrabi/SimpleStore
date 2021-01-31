using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class AccountOwner : DateTrackedModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string FullName
        {
            get { return $"{ FirstName } { LastName }"; }
        }
    }
}
