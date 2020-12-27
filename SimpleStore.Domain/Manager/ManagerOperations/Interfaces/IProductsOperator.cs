using SimpleStore.Domain.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Manager.ManagerOperations
{
    public interface IProductsOperator
    {
        bool InsertProduct(ProductModel product);
    }
}
