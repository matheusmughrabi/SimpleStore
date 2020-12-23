using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame.BusinessLogic.Database
{
    public class AuthenticationService : IAuthenticationService
    {
        private List<string> _users = new List<string>();

        public List<string> GetRegisteredUsers()
        {
            SetUpUsers();

            return _users;
        }

        private void SetUpUsers()
        {
            _users.Add("matheus");
            _users.Add("gustavo");
            _users.Add("meg");
        }
    }
}
