using SimpleStore.ConsoleUI.Control.InitialMenu;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.DataAccessLayer.Services.PizzasServices;
using SimpleStore.DataAccessLayer.Services.PizzaStoreServices;
using SimpleStore.Domain.Products.Models.Pizzas;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.Services.IPizzaStoreServices;
using SimpleStore.Domain.Services.PizzasServices;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.Stores.Models.PizzaStores;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserRegistration;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UsersRegistration;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IProductsService productsService = ServicesSimpleFactory.CreateProductsService();
            List<ProductModel> products = productsService.GetProducts();

            // TODO - Dependency Injection Container
            IAuthenticationService authenticationService = ServicesSimpleFactory.CreateAuthenticationService();
            IAccountsService accountsService = ServicesSimpleFactory.CreateAccountsService();
            IUserLogger userLogger = new UserLogger(authenticationService);
            IUserRegistrator userRegistrator = new UserRegistrator(authenticationService, accountsService);

            InitialMenu initialMenu = new InitialMenu(userLogger, userRegistrator);

            bool isActive = true;
            while (isActive)
            {
                isActive = initialMenu.RunInitialMenu();
            }
        }
    }

}
