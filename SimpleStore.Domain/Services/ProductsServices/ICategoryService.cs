using SimpleStore.Domain.Products;
using System.Collections.Generic;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface ICategoryService
    {
        List<CategoryModel> GetCategories();
        CategoryModel InsertCategory(CategoryModel category);
    }
}
