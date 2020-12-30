using SimpleStore.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public CategoryModel Category { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
    }
}
