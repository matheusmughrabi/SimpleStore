using SimpleStore.ConsoleUI.Factories;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.BeardStore
{
    public class BeardStoreProductsMenu
    {
        private CategoryModel _category;
        private List<ProductModel> _products;
        private IProductsService _productsService;

        public BeardStoreProductsMenu(CategoryModel category)
        {
            _category = category;
            _productsService = ServicesSimpleFactory.CreateProductsService();
            _products = _productsService.GetProductsByCategory(_category.Id);
        }

        public void RunBeardStoreProductMenu()
        {
            Console.Clear();
            Console.WriteLine($"This are the products we have under { _category.CategoryName }");

            int i = 1;
            foreach (ProductModel product in _products)
            {
                Console.WriteLine($"{ i } - { product.Name }");
                i += 1;
            }
        }
    }
}
