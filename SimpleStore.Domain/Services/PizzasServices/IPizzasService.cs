using SimpleStore.Domain.Products.Models.Pizzas;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Services.PizzasServices
{
    public interface IPizzasService
    {
        List<IPizza> GetPizzas(int pizzaStoreId);
    }
}
