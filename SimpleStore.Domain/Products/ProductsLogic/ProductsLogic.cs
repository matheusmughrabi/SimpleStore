using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.ProductsLogic
{
    public class ProductsLogic : IProductsLogic
    {
        private readonly IProductsService _productsService;
        private readonly ICategoryService _categoriesService;

        public ProductsLogic(IProductsService productsService, ICategoryService categoriesService)
        {
            _productsService = productsService;
            _categoriesService = categoriesService;
        }

        public List<ProductModel> GetProductsByCategory(int categoryId)
        {
            List<ProductModel>  products = _productsService.GetProductsByCategory(categoryId);
            return products;
        }

        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = _categoriesService.GetCategories();
            return categories;
        }
    }
}
