﻿using Autofac;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AccountsServices;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.DataAccessLayer.Services.ProductsServices;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration;
using SimpleStore.Domain.UsersAuthenticator.Users;

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
            builder.RegisterType<SqlServerCategoryService>().As<ICategoryService>();
            builder.RegisterType<SqlServerProductsService>().As<IProductsService>();

            builder.RegisterType<UserLogger>().As<IUserLogger>().SingleInstance();
            builder.RegisterType<UserRegistrator>().As<IUserRegistrator>();

            builder.RegisterType<UserModel>().AsSelf().SingleInstance();
            builder.RegisterType<AccountModel>().AsSelf().SingleInstance();

            builder.RegisterType<AccountsLogic>().AsSelf();

            builder.RegisterType<Application>().AsSelf();

            return builder.Build();
        }
    }
}