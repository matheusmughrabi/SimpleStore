using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface IProductsService
    {
        List<Product> GetProducts();
        Product GetProductByName(string name);
        List<Product> GetProductsByCategory(int categoryId);
        Product InsertProduct(Product product);
        bool UpdateProductQuantityInStock(int id, int quantity);
        bool DeleteProduct(int id);
    }
}
