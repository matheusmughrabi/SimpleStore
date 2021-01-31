using SimpleStore.Domain.Manager.ManagerModels;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.UsersAuthenticator.Users;
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
            ManagerModel manager = new ManagerModel();
            manager.User = new AccountOwner();
            manager.ManagerPermission = new ManagerPermissionModel();

            manager.User.Username = inputs[0];
            manager.ManagerPermission.PermissionTitle = inputs[1];

            bool isRegistrationSuccess = _managerCreator.RegisterManager(manager);
            if (isRegistrationSuccess == true)
            {
                Console.WriteLine($"{manager.User.Username} registered successfuly");
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
