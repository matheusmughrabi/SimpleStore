using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame.BusinessLogic.Login
{
    public interface IUserLogger
    {
        bool LoginUser(string username);
    }
}
