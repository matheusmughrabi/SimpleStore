using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenusAction
{
    public class BuyProductLogic
    {
        private readonly AccountsLogic _accountLogic;
        private readonly CategoryModel _category;
        private readonly IProductsService _productsService;

        public BuyProductLogic(AccountsLogic accountLogic, CategoryModel category, IProductsService productsService)
        {
            _accountLogic = accountLogic;
            _category = category;
            _productsService = productsService;
        }

        public bool BuyProduct(List<string> inputs)
        {
            List<ProductModel> products = _productsService.GetProductsByCategory(_category.Id);

            _accountLogic.ReloadCurrentAccount();
            Console.WriteLine($"{ _accountLogic.CurrentAccount.User.FirstName } your balance is { _accountLogic.CurrentAccount.Balance }");

            int i = 1;
            foreach (var product in products)
            {
                Console.WriteLine($"{ i } - { product.Name } price { product.RegularPrice }");
                i += 1;
            }

            Console.WriteLine("Select a product");

            string selectedProduct = Console.ReadLine();
            bool isInputValidUint = uint.TryParse(selectedProduct, out uint parsedSelectedProduct);

            if (isInputValidUint && parsedSelectedProduct <= products.Count)
            {
                if (_accountLogic.CurrentAccount.Balance < products[(int)parsedSelectedProduct - 1].RegularPrice)
                {
                    Console.WriteLine("You don't have enough credit to buy this product");
                    Console.ReadLine();
                    return false;
                }
                else
                {
                    _accountLogic.MakePurchase(products[(int)parsedSelectedProduct - 1].RegularPrice);

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
