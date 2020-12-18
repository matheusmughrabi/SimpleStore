using SimpleStore.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.Categories
{
    public class CategoryModel : BaseModel
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
