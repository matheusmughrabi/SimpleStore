using SimpleStore.Domain.BaseModels;
using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductStatuses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.ProductsModel
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public CategoryModel Category { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Description { get; set; }
        public ProductStatusModel ProductStatus { get; set; }
    }
}
