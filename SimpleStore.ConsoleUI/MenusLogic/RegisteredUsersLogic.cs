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
            List<UserModel> registeredUsers = _registeredUsersInfo.GetRegisteredUsers();

            foreach (var user in registeredUsers)
            {
                Console.WriteLine($"{ user.FullName } || { user.Email } || { user.Username } ");
            }

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            return true;
        }
    }
}
