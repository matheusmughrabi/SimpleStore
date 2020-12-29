﻿using SimpleStore.Domain.Manager.ManagerModels;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Manager.ManagerOperations.Interfaces
{
    public interface IRegisteredUsersInfo
    {
        List<ManagerModel> GetRegisteredUsers();
    }
}
