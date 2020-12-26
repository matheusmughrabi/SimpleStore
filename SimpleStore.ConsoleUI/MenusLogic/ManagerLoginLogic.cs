using SimpleStore.Domain.Manager.ManagerLogin;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenusLogic
{
    public class ManagerLoginLogic
    {
        private IManagerLogger _managerLogger;

        public ManagerLoginLogic(IManagerLogger managerLogger)
        {
            _managerLogger = managerLogger;
        }

        public bool Login(List<string> inputs)
        {
            bool isLogginSuccessful = _managerLogger.LoginManager(inputs[0], inputs[1]);

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
