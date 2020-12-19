using SimpleStore.ConsoleUI.Factories;
using SimpleStore.ConsoleUI.Factories.MenusFactories;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using SimpleStore.Domain.UsersAuthenticator.Authenticator.UserLogin;
using System;
using System.Collections.Generic;

namespace SimpleStore.ConsoleUI.Control.BeardStore
{
    public class BeardStoreCatalogMenu : BaseMenu
    {
        private AccountModel _account;
        private BeardStoreProductsMenu _beardStoreProductsMenu;
        private List<CategoryModel> _categories;
        private ICategoryService _categoryService;

        public BeardStoreCatalogMenu(AccountModel account)
        {
            _account = account;
            _categoryService = ServicesSimpleFactory.CreateCategoryService();
            _categories = _categoryService.GetCategories();
        }

        public override bool RunMenu()
        {
            DisplayBeardStoreCatalogMenuMessages();
            Console.WriteLine("0 - Exit store");

            string selectedCategory = Console.ReadLine();
            bool stayInBeardStoreCatalogMenu = ValidatesSelectedCategory(selectedCategory);

            return stayInBeardStoreCatalogMenu;
        }

        private void DisplayBeardStoreCatalogMenuMessages()
        {
            Console.Clear();
            Console.WriteLine($"This are the product categories we have");

            int i = 1;
            foreach (CategoryModel category in _categories)
            {
                Console.WriteLine($"{ i } - { category.CategoryName }");
                i += 1;
            }
        }

        private bool ValidatesSelectedCategory(string selectedCategory)
        {
            int parsedSelectedCategory;
            bool isInteger = int.TryParse(selectedCategory, out parsedSelectedCategory);

            if (parsedSelectedCategory >= 1 && parsedSelectedCategory <= _categories.Count && isInteger)
            {
                _beardStoreProductsMenu = MenuSimpleFactories.CreateBeardStoreProductsMenu(_account, _categories[parsedSelectedCategory - 1]);

                bool sameCategory = true;
                while (sameCategory)
                {
                    sameCategory = _beardStoreProductsMenu.RunMenu();
                }

                return true;
            }
            else if (parsedSelectedCategory == 0 && isInteger)
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
