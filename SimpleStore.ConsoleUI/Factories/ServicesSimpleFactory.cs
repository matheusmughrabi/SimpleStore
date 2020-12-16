using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AccountsServices;
using SimpleStore.DataAccessLayer.Services.AuthenticationServices;
using SimpleStore.DataAccessLayer.Services.PizzasServices;
using SimpleStore.DataAccessLayer.Services.PizzaStoreServices;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.AuthenticationServices;
using SimpleStore.Domain.Services.IPizzaStoreServices;
using SimpleStore.Domain.Services.PizzasServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Factories
{
    public static class ServicesSimpleFactory
    {
        private static IConnection _connection = new SqlServerConnection();

        public static IPizzaStoresService CreatePizzaStoresService()
        {
            return new SqlServerPizzaStoresService(_connection);
        }

        public static IAuthenticationService CreateAuthenticationService()
        {
            return new SqlServerAutenticationService(_connection);
        }

        public static IPizzasService CreatePizzasService()
        {
            return new SqlServerPizzasService(_connection);
        }

        public static IAccountsService CreateAccountsService()
        {
            return new SqlServerAccountsService(_connection);
        }
    }
}
