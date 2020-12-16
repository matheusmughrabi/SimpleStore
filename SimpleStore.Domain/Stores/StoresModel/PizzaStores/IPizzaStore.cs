using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Stores.Models.PizzaStores
{
    public interface IPizzaStore
    {
        int Id { get; set; }
        string StoreName { get; set; }
    }
}
