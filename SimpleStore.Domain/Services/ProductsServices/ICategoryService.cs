using SimpleStore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface ICategoryService
    {
        List<CategoryModel> GetCategories();
        CategoryModel InsertCategory(CategoryModel category);
    }
}
