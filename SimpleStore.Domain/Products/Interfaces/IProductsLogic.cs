using System.Collections.Generic;
using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Products.ProductsLogic
{
    public interface IProductsLogic
    {
        IEnumerable<Product> GetProductsByCategory(int categoryId);
        IEnumerable<Category> GetCategories();
    }
}
