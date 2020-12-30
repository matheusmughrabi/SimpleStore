using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.ProductsLogic
{
    public interface IProductsLogic
    {
        List<ProductModel> GetProductsByCategory(int categoryId);
        List<CategoryModel> GetCategories();
    }
}
