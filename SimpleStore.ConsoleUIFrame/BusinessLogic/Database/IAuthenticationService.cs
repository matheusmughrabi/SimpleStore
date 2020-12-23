using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame.BusinessLogic.Database
{
    public interface IAuthenticationService
    {
        List<string> GetRegisteredUsers();
    }
}
