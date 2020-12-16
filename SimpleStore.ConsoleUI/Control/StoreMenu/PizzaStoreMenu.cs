using SimpleStore.ConsoleUI.Factories;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.AccountsServices;
using SimpleStore.DataAccessLayer.Services.PizzasServices;
using SimpleStore.Domain.Products.Models.Pizzas;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.PizzasServices;
using SimpleStore.Domain.Stores.Models.PizzaStores;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.SpecificStoreMenu
{
    public class PizzaStoreMenu
    {
        private IPizzaStore _pizzaStore;
        private IPizzasService _pizzaService;
        private List<IPizza> _pizzas;
        private AccountModel _account;
        private AccountsLogic _accountLogic;

        public PizzaStoreMenu(AccountModel account, IPizzaStore pizzaStore)
        {
            _pizzaStore = pizzaStore;
            _pizzaService = ServicesSimpleFactory.CreatePizzasService();
            _pizzas = _pizzaService.GetPizzas(_pizzaStore.Id);
            _account = account;

            IAccountsService accountService = ServicesSimpleFactory.CreateAccountsService();
            _accountLogic = new AccountsLogic(_account, accountService);
        }

        public bool RunPizzaStoreMenu()
        {
            DisplayPizzaStoreMenuMessages();
            Console.WriteLine("0 - Exit store");

            string chosenPizza = Console.ReadLine();
            bool stayInPizzaStore = OrderSelectedPizza(chosenPizza);

            return stayInPizzaStore;
        }

        private void DisplayPizzaStoreMenuMessages()
        {
            Console.Clear();
            Console.WriteLine($"Your current balance is: { _account.Balance }");       
            Console.WriteLine($"This is the Menu of { _pizzaStore.StoreName }");       

            int i = 1;
            foreach (IPizza pizza in _pizzas)
            {
                Console.WriteLine($"{ i } - { pizza.Type } which cost {pizza.Price}");
                i += 1;
            }
        }

        private bool OrderSelectedPizza(string chosenPizza)
        {
            int parsedChosenPizza;
            bool isInteger = int.TryParse(chosenPizza, out parsedChosenPizza);

            if (parsedChosenPizza >= 1 && parsedChosenPizza <= _pizzas.Count && isInteger)
            {
                IPizza selectedPizza = _pizzas[parsedChosenPizza - 1];
                _accountLogic.MakePurchase(selectedPizza.Price);

                Console.WriteLine($"You chose: {selectedPizza.Type}");
                Console.WriteLine($"The price is: {selectedPizza.Price}");
                Console.WriteLine($"Your balance after the purchase is: {_account.Balance}");
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadLine();
                return true;
            }
            else if (parsedChosenPizza == 0 && isInteger)
            {
                return false;
            }
            else
            {
                Console.WriteLine("Invalid option, press 'Enter' to try again");
                Console.ReadLine();
                return true;
            }
        }
    }
}
