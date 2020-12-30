using SimpleStore.Domain.Products;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public interface ICategoryOperator
    {
        bool InsertCategory(CategoryModel category);
        bool DeleteCategory(string categoryName);
    }
}
