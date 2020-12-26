using SimpleStore.Domain.Products.Categories;
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
