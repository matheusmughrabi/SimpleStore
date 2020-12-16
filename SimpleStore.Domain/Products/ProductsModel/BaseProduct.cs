using SimpleStore.Domain.Products.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products
{
    public abstract class BaseProduct : IBaseProduct
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
    }
}
