using SimpleStore.Domain.Products.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public interface ICategoryOperator
    {
        bool InsertCategory(CategoryModel category);
    }
}
