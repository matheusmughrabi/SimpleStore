using SimpleStore.Domain.Products;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface IProductsService
    {
        List<ProductModel> GetProducts();
        List<ProductModel> GetProductsByCategory(int categoryId);
        ProductModel InsertProduct(ProductModel product);
    }
}
