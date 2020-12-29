using SimpleStore.Domain.Manager.ManagerModels;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenusLogic
{
    public class RegisteredUsersLogic
    {
        private readonly IRegisteredUsersInfo _registeredUsersInfo;

        public RegisteredUsersLogic(IRegisteredUsersInfo registeredUsersInfo)
        {
            _registeredUsersInfo = registeredUsersInfo;
        }

        public bool DisplayRegisteredUsers(List<string> inputs)
        {
            List<ManagerModel> registeredUsersAndTitles = _registeredUsersInfo.GetRegisteredUsers();

            foreach (var user in registeredUsersAndTitles)
            {
                if (user.ManagerPermission.PermissionTitle == string.Empty)
                {
                    user.ManagerPermission.PermissionTitle = "Not a manager";
                }
                Console.WriteLine($"{ user.User.FullName } || { user.User.Email } || { user.User.Username } || {user.ManagerPermission.PermissionTitle}");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            return true;
        }
    }
}
