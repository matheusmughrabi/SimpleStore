using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Product : DateTrackedModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public Category Category { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal DiscountedPrice { get; set; }
        public string Description { get; set; }
        public int QuantityInStock { get; set; }
    }
}
