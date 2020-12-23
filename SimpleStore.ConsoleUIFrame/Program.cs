using Autofac;
using SimpleStore.ConsoleUIFrame.MenuFrame;
using SimpleStore.ConsoleUIFrame.Menus;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUIFrame
{
    class Program
    {
        static void Main(string[] args)
        {
            IContainer container = new DependencyInjector().CreateContainer();

            using (var scope = container.BeginLifetimeScope())
            {
                var initialMenuRun = scope.Resolve<Application>();
                initialMenuRun.RunApp();
            }
        }
    }
}
