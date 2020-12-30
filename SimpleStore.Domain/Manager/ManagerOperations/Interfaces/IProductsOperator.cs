using SimpleStore.Domain.Products;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public interface IProductsOperator
    {
        bool InsertProduct(ProductModel product);
    }
}
