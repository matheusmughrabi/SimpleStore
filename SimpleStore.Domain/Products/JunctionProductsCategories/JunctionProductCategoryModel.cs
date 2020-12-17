using SimpleStore.Domain.BaseModels;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.JunctionProductsCategories
{
    public class JunctionProductCategoryModel : BaseModel
    {
        public CategoryModel Category { get; set; }
        public ProductModel Product { get; set; }
    }
}
