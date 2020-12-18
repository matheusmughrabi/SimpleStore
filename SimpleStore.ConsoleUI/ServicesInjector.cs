using Autofac;
using Microsoft.Extensions.DependencyInjection;
using SimpleStore.ConsoleUI.Control.InitialMenu;
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
    public class ServicesInjector
    {
        public IServiceProvider CreateServiceProvider()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<IUserLogger, UserLogger>();
            services.AddSingleton<IUserRegistrator, UserRegistrator>();

            services.AddScoped<InitialMenu>();

            return services.BuildServiceProvider();
        }

        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SqlServerConnection>().As<IConnection>();
            builder.RegisterType<SqlServerAutenticationService>().As<IAuthenticationService>();
            builder.RegisterType<SqlServerAccountsService>().As<IAccountsService>();

            builder.RegisterType<UserLogger>().As<IUserLogger>();
            builder.RegisterType<UserRegistrator>().As<IUserRegistrator>();

            builder.RegisterType<InitialMenu>().AsSelf();

            return builder.Build();
        }
    }
}
