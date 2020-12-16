using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.Models.Pizzas
{
    public interface IPizza : IBaseProduct
    {
        string Type { get; set; }
        string Sauce { get; set; }
    }
}
