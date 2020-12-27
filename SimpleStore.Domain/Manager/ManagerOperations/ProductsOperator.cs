using SimpleStore.Domain.Products;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class ProductsOperator : IProductsOperator
    {
        private readonly IProductsService _productsService;
        private readonly ICategoryService _categoryService;

        public ProductsOperator(IProductsService productsService, ICategoryService categoryService)
        {
            _productsService = productsService;
            _categoryService = categoryService;
        }

        public bool InsertProduct(ProductModel product)
        {
            CategoryModel category = GetCategoryByName(product.Category.CategoryName);
            product.Category.Id = category.Id;
            _productsService.InsertProduct(product);

            return true;
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
