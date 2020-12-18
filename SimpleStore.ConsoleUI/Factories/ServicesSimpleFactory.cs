﻿using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AccountsServices;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.DataAccessLayer.Services.ProductsServices;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.Services.ProductsServices;

namespace SimpleStore.ConsoleUI.Factories
{
    public static class ServicesSimpleFactory
    {
        private static IConnection _connection = new SqlServerConnection();

        public static IAuthenticationService CreateAuthenticationService()
        {
            return new SqlServerAutenticationService(_connection);
        }

        public static IAccountsService CreateAccountsService()
        {
            return new SqlServerAccountsService(_connection);
        }

        public static IProductsService CreateProductsService()
        {
            return new SqlServerProductsService(_connection);
        }

        public static ICategoryService CreateCategoryService()
        {
            return new SqlServerCategoryService(_connection);
        }
    }
}
