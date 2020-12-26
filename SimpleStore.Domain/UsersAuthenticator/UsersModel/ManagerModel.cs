using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.UsersAuthenticator.UsersModel
{
    public class ManagerModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public string ManagerPermission { get; set; }

        public ManagerModel()
        {

        }
        public ManagerModel(UserModel user)
        {
            User = user;
        }
    }
}
