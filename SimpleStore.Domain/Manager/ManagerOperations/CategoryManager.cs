using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Domain.Products;
using SimpleStore.Models.Models;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public class CategoryManager : ICategoryOperator
    {
        private readonly ICategoryService _categoryService;
        private List<Category> _registeredCategories;

        public CategoryManager(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public bool InsertCategory(Category category)
        {
            if (ManagerLogger.CurrentManager.ManagerPermission.PermissionTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            _registeredCategories = _categoryService.GetCategories();

            foreach (var registeredCategory in _registeredCategories)
            {
                if (registeredCategory.Name == category.Name)
                {
                    return false;
                }
                if (string.IsNullOrEmpty(category.Name))
                {
                    return false;
                }
            }

            _categoryService.InsertCategory(category);
            return true;
        }

        public bool DeleteCategory(string categoryName)
        {
            if (ManagerLogger.CurrentManager.ManagerPermission.PermissionTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            Category category = _categoryService.GetCategoryByName(categoryName);
            if (category.Id == 0)
            {
                return false;
            }

            _categoryService.DeleteCategory(category.Id);

            return true;
        }
    }
}
