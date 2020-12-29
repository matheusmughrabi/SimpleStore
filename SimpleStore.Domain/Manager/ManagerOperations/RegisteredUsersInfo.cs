﻿using SimpleStore.Domain.Manager.ManagerModels;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class RegisteredUsersInfo : IRegisteredUsersInfo
    {
        private readonly IManagerService _managerService;

        public RegisteredUsersInfo(IManagerService managerService)
        {
            _managerService = managerService;
        }

        public List<ManagerModel> GetRegisteredUsers()
        {
            List<ManagerModel> registeredUsersAndTitles = _managerService.GetUsersAndTitles();

            return registeredUsersAndTitles;
        }
    }
}
