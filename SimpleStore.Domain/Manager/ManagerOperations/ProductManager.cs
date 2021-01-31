using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;
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

        public bool InsertProduct(Product product)
        {
            Category category = GetCategoryByName(product.Category.Name);
            product.Category.Id = category.Id;
            product.QuantityInStock = 0;
            _productsService.InsertProduct(product);

            return true;
        }

        public bool BuyProduct(string name, int quantity)
        {
            Product product = GetProductIdByName(name);
            if (product == null)
            {
                return false;
            }

            _productsService.UpdateProductQuantityInStock(product.Id, quantity);

            return true;
        }

        public bool DeleteProduct(string name)
        {
            if (ManagerLogger.CurrentManager.ManagerPermission.PermissionTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            Product product = _productsService.GetProductByName(name);
            if (product.Id == 0)
            {
                return false;
            }

            _productsService.DeleteProduct(product.Id);

            return true;
        }

        private Product GetProductIdByName(string name)
        {
            List<Product> products = _productsService.GetProducts();
            foreach (var product in products)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }

            return null;
        }

        private Category GetCategoryByName(string name)
        {
            List<Category> registeredCategories = _categoryService.GetCategories();

            foreach (var category in registeredCategories)
            {
                if (category.Name == name)
                {
                    return category;
                }
            }

            throw new Exception();
        }
    }
}
