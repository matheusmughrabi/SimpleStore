using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public interface ICategoryOperator
    {
        bool InsertCategory(Category category);
        bool DeleteCategory(string name);
    }
}
