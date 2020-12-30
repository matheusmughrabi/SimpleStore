using SimpleStore.Domain.Products;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class ProductManager : IProductsOperator
    {
        private readonly IProductsService _productsService;
        private readonly ICategoryService _categoryService;

        public ProductManager(IProductsService productsService, ICategoryService categoryService)
        {
            _productsService = productsService;
            _categoryService = categoryService;
        }

        public bool InsertProduct(ProductModel product)
        {
            CategoryModel category = GetCategoryByName(product.Category.CategoryName);
            product.Category.Id = category.Id;
            product.QuantityInStock = 0;
            _productsService.InsertProduct(product);

            return true;
        }

        public bool BuyProduct(string name, int quantity)
        {
            ProductModel product = GetProductIdByName(name);
            if (product == null)
            {
                return false;
            }

            _productsService.UpdateProductQuantityInStock(product.Id, quantity);

            return true;
        }

        private ProductModel GetProductIdByName(string name)
        {
            List<ProductModel> products = _productsService.GetProducts();
            foreach (var product in products)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }

            return null;
        }

        private CategoryModel GetCategoryByName(string categoryName)
        {
            List<CategoryModel> registeredCategories = _categoryService.GetCategories();

            foreach (var category in registeredCategories)
            {
                if (category.CategoryName == categoryName)
                {
                    return category;
                }
            }

            throw new Exception();
        }
    }
}
