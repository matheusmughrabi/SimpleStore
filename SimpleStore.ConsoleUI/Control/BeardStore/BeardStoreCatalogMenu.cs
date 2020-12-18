using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.BeardStore
{
    public class BeardStoreCatalogMenu
    {
        private List<CategoryModel> _categories;
        private ICategoryService _categoryService;

        public BeardStoreCatalogMenu()
        {
            _categoryService = ServicesSimpleFactory.CreateCategoryService();
            _categories = _categoryService.GetCategories();
        }

        public bool RunBeardStoreCatalogMenu()
        {
            DisplayBeardStoreCatalogMenuMessages();
            Console.WriteLine("0 - Exit store");

            string selectedCategory = Console.ReadLine();
            bool isValidCategory = ValidatesSelectedCategory(selectedCategory);
            if (isValidCategory)
            {
                Console.WriteLine("Press enter to continuer (this is the isValidCategory if)");
                Console.ReadLine();
            }

            return isValidCategory;
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
