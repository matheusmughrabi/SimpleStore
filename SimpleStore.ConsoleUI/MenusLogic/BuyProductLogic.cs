﻿using SimpleStore.ConsoleUI.MenuFramework.MenuItems;
using SimpleStore.Domain.Accounts;
using SimpleStore.Domain.Accounts.Interfaces;
using SimpleStore.Domain.Products;
using SimpleStore.Domain.Products.ProductsLogic;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class BuyProductLogic
    {
        private readonly IAccountsLogic _accountLogic;
        private readonly Category _category;
        private readonly IProductsLogic _productsLogic;

        public BuyProductLogic(IAccountsLogic accountLogic, Category category, IProductsLogic productsLogic)
        {
            _accountLogic = accountLogic;
            _category = category;
            _productsLogic = productsLogic;
        }

        public bool BuyProduct(List<string> inputs)
        {
            List<Product> productsInCategory = (List<Product>)_productsLogic.GetProductsByCategory(_category.Id);

            _accountLogic.ReloadCurrentAccount();
            Console.WriteLine($"{ _accountLogic.CurrentAccount.AccountOwner.FirstName } your balance is { _accountLogic.CurrentAccount.Balance }");


            List<Tuple<string, string, decimal, string>> products = new List<Tuple<string, string, decimal, string>>();
            foreach (var product in productsInCategory)
            {
                products.Add(Tuple.Create(product.Name, product.Brand, product.RegularPrice, product.Description));
            }

            Console.WriteLine(products.ToStringTable(
              new[] { "Name", "Brand", "Price", "Description" },
              a => a.Item1, a => a.Item2, a => a.Item3, a => a.Item4));

            Console.WriteLine("Select a product");

            string selectedProduct = Console.ReadLine();
            bool isInputValidUint = uint.TryParse(selectedProduct, out uint parsedSelectedProduct);

            if (isInputValidUint && parsedSelectedProduct <= productsInCategory.Count)
            {
                if (_accountLogic.CurrentAccount.Balance < productsInCategory[(int)parsedSelectedProduct - 1].RegularPrice)
                {
                    Console.WriteLine("You don't have enough credit to buy this product");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    _accountLogic.MakePurchase(productsInCategory[(int)parsedSelectedProduct - 1].RegularPrice);

                    Console.WriteLine("Purchase successful");
                    Console.ReadLine();
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
