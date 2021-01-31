using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Products.Interfaces
{
    public interface IProductsOperator
    {
        bool InsertProduct(Product product);
        bool BuyProduct(string name, int quantity);
        bool DeleteProduct(string name);
    }
}
