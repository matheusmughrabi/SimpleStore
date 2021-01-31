using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Domain.Services.ProductsServices;
using SimpleStore.Models.Models;
using System.Collections.Generic;

namespace SimpleStore.Domain.Products.ProductsLogic
{
    public class ProductsLogic : IProductsLogic
    {
        private readonly IUnityOfWork _unityOfWork;

        public ProductsLogic(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryId)
        {
            IEnumerable<Product> products = _unityOfWork.Product.GetAll(p => p.CategoryId == categoryId, null, "Category");
            return products;
        }

        public IEnumerable<Category> GetCategories()
        {
            IEnumerable<Category> categories = _unityOfWork.Category.GetAll();
            return categories;
        }
    }
}
