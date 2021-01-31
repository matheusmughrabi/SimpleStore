using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Models.Models;
using System.Collections.Generic;

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

        public List<Product> GetProductsByCategory(int categoryId)
        {
            List<Product> products = _productsService.GetProductsByCategory(categoryId);
            return products;
        }

        public List<Category> GetCategories()
        {
            List<Category> categories = _categoriesService.GetCategories();
            return categories;
        }
    }
}
