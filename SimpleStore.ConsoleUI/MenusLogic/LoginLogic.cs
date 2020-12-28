using SimpleStore.ConsoleUI.MenuFrame;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class LoginLogic
    {
        private IUserLogger _userLogger;

        public LoginLogic(IUserLogger userLogger)
        {
            _userLogger = userLogger;
        }

        public bool Login(List<string> inputs)
        {
            bool isLogginSuccessful = _userLogger.LoginUser(inputs[0], inputs[1]);

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

        public void Logout()
        {
            _userLogger.Logout();
        }
    }
}
