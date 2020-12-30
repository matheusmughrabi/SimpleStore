using SimpleStore.Domain.Products;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface IProductsService
    {
        List<ProductModel> GetProducts();
        ProductModel GetProductByName(string name);
        List<ProductModel> GetProductsByCategory(int categoryId);
        ProductModel InsertProduct(ProductModel product);
        bool UpdateProductQuantityInStock(int id, int quantity);
        bool DeleteProduct(int id);
    }
}
