using SimpleStore.Domain.Products;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface ICategoryService
    {
        List<CategoryModel> GetCategories();
        CategoryModel GetCategoryByName(string categoryName);
        CategoryModel InsertCategory(CategoryModel category);
        bool DeleteCategory(int id);
    }
}
