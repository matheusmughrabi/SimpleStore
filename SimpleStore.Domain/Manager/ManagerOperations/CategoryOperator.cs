using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class CategoryOperator : ICategoryOperator
    {
        private readonly ICategoryService _categoryService;

        public CategoryOperator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public bool InsertCategory(CategoryModel category)
        {
            _categoryService.InsertCategory(category);
            return true;
        }
    }
}
