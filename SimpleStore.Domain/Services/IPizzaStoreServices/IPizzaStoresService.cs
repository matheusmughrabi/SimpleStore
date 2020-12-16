using SimpleStore.Domain.Stores.Models.PizzaStores;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Services.IPizzaStoreServices
{
    public interface IPizzaStoresService
    {
        List<IPizzaStore> GetPizzaStores();
    }
}
