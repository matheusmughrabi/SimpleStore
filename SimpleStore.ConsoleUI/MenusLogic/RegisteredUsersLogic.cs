using SimpleStore.Models.Models;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using System;
using System.Collections.Generic;
using SimpleStore.ConsoleUI.MenuFramework.MenuItems;

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
            IEnumerable <AccountOwner> registeredUsersAndTitles = _registeredUsersInfo.GetRegisteredUsers();

            List<Tuple<string, string, string, string>> users = new List<Tuple<string, string, string, string>>();
            foreach (var user in registeredUsersAndTitles)
            {
                if (user.Role.RoleTitle == string.Empty)
                {
                    user.Role.RoleTitle = "Not a manager";
                }
                users.Add(Tuple.Create(user.FullName, user.Email, user.Username, user.Role.RoleTitle));
            }

            Console.WriteLine(users.ToStringTable(
              new[] { "Name", "Email", "Username", "Permission Title" },
              a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4));

            Console.WriteLine("Press any key to continue");
            Console.ReadLine();

            return true;
        }
    }
}
