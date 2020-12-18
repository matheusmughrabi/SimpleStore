using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services.AccountServices;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.BeardStore
{
    public class BeardStoreProductsMenu
    {
        private AccountModel _account;
        private CategoryModel _category;
        private List<ProductModel> _products;
        private IProductsService _productsService;
        private AccountsLogic _accountLogic;

        public BeardStoreProductsMenu(AccountModel account, CategoryModel category)
        {
            _account = account;
            _category = category;
            _productsService = ServicesSimpleFactory.CreateProductsService();
            _products = _productsService.GetProductsByCategory(_category.Id);

            IAccountsService accountService = ServicesSimpleFactory.CreateAccountsService();
            _accountLogic = new AccountsLogic(_account, accountService);
        }

        public bool RunBeardStoreProductMenu()
        {
            DisplayBeardStoreProductsMenuMessages();
            Console.WriteLine("0 - Exit");

            string selectedProductInput = Console.ReadLine();
            bool stayInProductsMenu = OrderSelectedProduct(selectedProductInput);

            

            return stayInProductsMenu;
        }

        private void DisplayBeardStoreProductsMenuMessages()
        {
            Console.Clear();
            Console.WriteLine($"Your current balance is: { _account.Balance }");
            Console.WriteLine($"This are the products we have under { _category.CategoryName }");

            int i = 1;
            foreach (ProductModel product in _products)
            {
                Console.WriteLine($"{ i } - { product.Name }");
                i += 1;
            }
        }

        private bool OrderSelectedProduct(string selectedProductInput)
        {
            int parsedSelectedProduct;
            bool isInteger = int.TryParse(selectedProductInput, out parsedSelectedProduct);

            if (parsedSelectedProduct >= 1 && parsedSelectedProduct <= _products.Count && isInteger)
            {
                ProductModel selectedProduct = _products[parsedSelectedProduct - 1];
                bool isPurchaseSuccessful = _accountLogic.MakePurchase(selectedProduct.RegularPrice);

                if (!isPurchaseSuccessful)
                {
                    Console.WriteLine("You don't have enough money to buy this product, press 'Enter' to continue");
                    Console.ReadLine();
                    return true;
                }

                Console.WriteLine($"You chose: {selectedProduct.Name}");
                Console.WriteLine($"The price is: {selectedProduct.RegularPrice}");
                Console.WriteLine($"Your balance after the purchase is: {_account.Balance}");
                Console.WriteLine("Press 'Enter' to continue");
                Console.ReadLine();

                return true;
            }
            else if (parsedSelectedProduct == 0 && isInteger)
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
