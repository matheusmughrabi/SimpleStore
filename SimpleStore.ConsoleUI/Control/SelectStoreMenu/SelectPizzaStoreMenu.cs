using SimpleStore.ConsoleUI.Control.SpecificStoreMenu;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.DataAccessLayer.Connections;
using SimpleStore.DataAccessLayer.Services.PizzaStoreServices;
using SimpleStore.Domain.Services;
using SimpleStore.Domain.Services.IPizzaStoreServices;
using SimpleStore.Domain.Stores.Models.PizzaStores;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.ChooseStoreMenu
{
    public class SelectPizzaStoreMenu : BaseSelectStoreMenu
    {
        private IPizzaStore _pizzaStore;
        private PizzaStoreMenu _pizzaStoreMenu;
        private List<IPizzaStore> _pizzaStores;
        private AccountModel _account;

        public SelectPizzaStoreMenu(AccountModel account)
        {
            _account = account;
        }

        public override bool RunMainMenu()
        {
            MainMenuMessage();
            string selectedOption = Console.ReadLine();

            if (selectedOption == "0")
            {
                return false;
            }
            else if (SelectedPizzaStore(selectedOption))
            {
                _pizzaStoreMenu = new PizzaStoreMenu(_account, _pizzaStore);
            }
            else
            {
                InvalidOptionMessage();
                return true;
            }

            bool samePizzaStore = true;
            while (samePizzaStore)
            {
                samePizzaStore = _pizzaStoreMenu.RunPizzaStoreMenu();
            }

            return true;
        }

        private List<IPizzaStore> GetPizzaStores()
        {
            IPizzaStoresService pizzaService = ServicesSimpleFactory.CreatePizzaStoresService();
            return pizzaService.GetPizzaStores();
        }

        private void MainMenuMessage()
        {
            _pizzaStores = GetPizzaStores();

            Console.Clear();
            Console.WriteLine("Choose amongst the following options");

            int i = 1;
            foreach (IPizzaStore pizza in _pizzaStores)
            {
                Console.WriteLine($"{ i } - { pizza.StoreName }");
                i += 1;
            }
            Console.WriteLine("0 - Exit");
        }

        private void InvalidOptionMessage()
        {
            Console.WriteLine("Invalid option, press 'Enter' to try again");
            Console.ReadLine();
        }

        private bool SelectedPizzaStore(string chosenPizzaStore)
        {
            int parsedChosenPizzaStore = int.Parse(chosenPizzaStore);
            if (parsedChosenPizzaStore >= 1 && parsedChosenPizzaStore <= _pizzaStores.Count)
            {
                _pizzaStore = _pizzaStores[parsedChosenPizzaStore - 1];

                return true;
            }
            else if (parsedChosenPizzaStore == 0)
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
