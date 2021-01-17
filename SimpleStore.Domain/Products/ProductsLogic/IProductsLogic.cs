using System.Collections.Generic;

namespace SimpleStore.Domain.Products.ProductsLogic
{
    public interface IProductsLogic
    {
        List<ProductModel> GetProductsByCategory(int categoryId);
        List<CategoryModel> GetCategories();
    }
}
