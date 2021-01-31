using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public interface IProductsOperator
    {
        bool InsertProduct(Product product);
        bool BuyProduct(string name, int quantity);
        bool DeleteProduct(string name);
    }
}
