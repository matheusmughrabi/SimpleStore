using SimpleStore.Models.Models;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenusLogic
{
    public class ManagerCreatorLogic
    {
        private readonly IManagerCreator _managerCreator;

        public ManagerCreatorLogic(IManagerCreator managerCreator)
        {
            _managerCreator = managerCreator;
        }

        public bool CreateManager(List<string> inputs)
        {
            AccountOwner manager = new AccountOwner();
            manager.Role = new Roles();

            manager.Username = inputs[0];
            manager.Role.PermissionTitle = inputs[1];

            bool isRegistrationSuccess = _managerCreator.RegisterManager(manager);
            if (isRegistrationSuccess == true)
            {
                Console.WriteLine($"{manager.Username} registered successfuly");
            }
            else
            {
                Console.WriteLine("Registration failed");
            }

            Console.ReadLine();
            return isRegistrationSuccess;
        }
    }
}
