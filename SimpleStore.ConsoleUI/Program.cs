using Autofac;
using SimpleStore.ConsoleUI.Control.InitialMenu;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AccountsServices;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration;
using System;

namespace SimpleStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new ServicesInjector().CreateContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var initialMenu = scope.Resolve<InitialMenu>();

                bool isActive = true;
                while (isActive)
                {
                    isActive = initialMenu.RunInitialMenu();
                }
            } 
        }
    }
}
