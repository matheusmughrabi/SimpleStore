using System.Collections.Generic;
using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Products.ProductsLogic
{
    public interface IProductsLogic
    {
        List<Product> GetProductsByCategory(int categoryId);
        List<Category> GetCategories();
    }
}
