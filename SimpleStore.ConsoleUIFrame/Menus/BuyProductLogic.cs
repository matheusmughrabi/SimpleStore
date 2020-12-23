using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsLogic;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUIFrame.Menus
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
            uint parsedInput;
            uint.TryParse(inputs[0], out parsedInput);

            ProductModel product = _productsService.GetProductsByCategory(_category.Id)[(int)parsedInput];

            if (_accountLogic.CurrentAccount.Balance < product.RegularPrice)
            {
                Console.WriteLine("You don't have enough credit to buy this product");
                Console.ReadLine();
                return false;
            }
            else
            {
                _accountLogic.MakePurchase(product.RegularPrice);

                Console.WriteLine("Purchase successful");
                Console.ReadLine();
                return false;
            }
        }
    }
}
