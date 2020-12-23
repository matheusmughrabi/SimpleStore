using SimpleStore.ConsoleUIFrame.BusinessLogic.Login;
using SimpleStore.ConsoleUIFrame.MenuFrame;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame.Menus
{
    public class LoginLogic
    {
        private List<string> _users = new List<string>();
        private IUserLogger _userLogger;

        public LoginLogic(IUserLogger userLogger)
        {
            _userLogger = userLogger;
        }

        public bool Login(List<string> inputs)
        {
            bool isLogginSuccessful = _userLogger.LoginUser(inputs[0]);

            if (isLogginSuccessful)
            {
                Console.WriteLine("Login successful");
            }
            else
            {
                Console.WriteLine("Login failed");
            }

            Console.ReadLine();
            return isLogginSuccessful;
        }
    }
}
