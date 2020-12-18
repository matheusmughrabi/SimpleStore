using SimpleStore.ConsoleUI.Control.Validators;
using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Domain.UsersAccounts.AccountsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.BeardStore
{
    public class BeardStoreCatalogMenu
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

        public bool RunBeardStoreCatalogMenu()
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
                _beardStoreProductsMenu = new BeardStoreProductsMenu(_account, _categories[parsedSelectedCategory - 1]);

                bool sameCategory = true;
                while (sameCategory)
                {
                    sameCategory = _beardStoreProductsMenu.RunBeardStoreProductMenu();
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
