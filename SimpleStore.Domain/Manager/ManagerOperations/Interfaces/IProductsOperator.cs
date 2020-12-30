using SimpleStore.Domain.Products;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public interface IProductsOperator
    {
        bool InsertProduct(ProductModel product);
        bool BuyProduct(string name, int quantity);
        bool DeleteProduct(string name);
    }
}
