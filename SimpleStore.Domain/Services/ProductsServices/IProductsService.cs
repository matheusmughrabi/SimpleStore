using SimpleStore.Domain.Products.ProductsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Services.ProductsServices
{
    public interface IProductsService
    {
        List<ProductModel> GetProducts();
        List<ProductModel> GetProductsByCategory(int categoryId);
    }
}
