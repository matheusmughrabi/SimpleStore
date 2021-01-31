using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryByName(string name);
        Category InsertCategory(Category category);
        bool DeleteCategory(int id);
    }
}
