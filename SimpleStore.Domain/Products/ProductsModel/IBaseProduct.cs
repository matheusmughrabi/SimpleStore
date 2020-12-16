using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.Models
{
    public interface IBaseProduct
    {
        int Id { get; set; }
        decimal Price { get; set; }
    }
}
