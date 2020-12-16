using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.Models.Pizzas
{
    public class PizzaModel : BaseProduct, IPizza
    {
        public string Type { get; set; }
        public string Sauce { get; set; }
    }
}
