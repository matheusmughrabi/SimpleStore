using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Stores.Models.PizzaStores
{
    public class PizzaStoreModel : IPizzaStore
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
    }
}
