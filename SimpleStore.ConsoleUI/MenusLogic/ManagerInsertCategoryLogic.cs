using SimpleStore.Domain.Manager.ManagerOperations;
using SimpleStore.Domain.Products.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenusLogic
{
    public class ManagerInsertCategoryLogic
    {
        private readonly ICategoryOperator _categoryOperator;

        public ManagerInsertCategoryLogic(ICategoryOperator categoryOperator)
        {
            _categoryOperator = categoryOperator;
        }

        public bool InsertCategory(List<string> inputs)
        {
            CategoryModel category = new CategoryModel();
            category.CategoryName = inputs[0];

            _categoryOperator.InsertCategory(category);

            return true;
        }
    }
}
