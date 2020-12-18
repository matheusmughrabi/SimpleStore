using Autofac;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.ConsoleUI.Control.InitialMenu;
using SimpleStore.ConsoleUI.Factories.MenuFactories;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
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
    public class DependencyInjector
    {
        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SqlServerConnection>().As<IConnection>();
            builder.RegisterType<SqlServerAutenticationService>().As<IAuthenticationService>();
            builder.RegisterType<SqlServerAccountsService>().As<IAccountsService>();

            builder.RegisterType<RootMenuFactory>().AsSelf();
            builder.RegisterType<LoginMenuFactory>().AsSelf();
            builder.RegisterType<RegisterMenuFactory>().AsSelf();

            builder.RegisterType<UserLogger>().As<IUserLogger>();
            builder.RegisterType<UserRegistrator>().As<IUserRegistrator>();

            builder.RegisterType<InitialMenu>().AsSelf();

            return builder.Build();
        }
    }
}
