using Autofac;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Data.Repository;
using SimpleStore.DataAccessLayer.Services.AccountsServices;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.DataAccessLayer.Services.ManagerServices;
using SimpleStore.DataAccessLayer.Services.ProductsServices;
using SimpleStore.Domain.IRepository;
using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Domain.Manager.ManagerOperations;
using SimpleStore.Domain.Manager.ManagerOperations.Interfaces;
using SimpleStore.Domain.Products.ProductsLogic;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using SimpleStore.Models.Models;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration;

namespace SimpleStore.ConsoleUI
{
    public class DependencyInjector
    {
        public IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SqlServerConnection>().As<IConnection>();
            builder.RegisterType<SqlServerAuthenticationService>().As<IAuthenticationService>();
            builder.RegisterType<SqlServerManagerService>().As<IManagerService>();
            builder.RegisterType<SqlServerAccountsService>().As<IAccountsService>();
            builder.RegisterType<SqlServerCategoryService>().As<ICategoryService>();
            builder.RegisterType<SqlServerProductsService>().As<IProductsService>();

            builder.RegisterType<RepositorySPCallSqlServer>().As<IRepositorySPCall>();

            builder.RegisterType<UserLogger>().As<IUserLogger>().SingleInstance();
            builder.RegisterType<ManagerLogger>().As<IManagerLogger>().SingleInstance();
            builder.RegisterType<UserRegistrator>().As<IUserRegistrator>();
            builder.RegisterType<ManagerCreator>().As<IManagerCreator>();
            builder.RegisterType<RegisteredUsersInfo>().As<IRegisteredUsersInfo>();
            builder.RegisterType<ProductsLogic>().As<IProductsLogic>();

            builder.RegisterType<AccountOwner>().AsSelf().SingleInstance();
            builder.RegisterType<Account>().AsSelf().SingleInstance();

            builder.RegisterType<AccountsLogic>().AsSelf();
            builder.RegisterType<CategoryManager>().As<ICategoryOperator>();
            builder.RegisterType<ProductManager>().As<IProductsOperator>();

            builder.RegisterType<Application>().AsSelf();

            return builder.Build();
        }
    }
}
