using SimpleStore.DataAccess.Data.Repository.IRepository;
using SimpleStore.Domain.Manager.ManagerLogin;
using SimpleStore.Domain.Products.Interfaces;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;

namespace SimpleStore.Domain.Products
{
    public class ProductCreator : IProductsOperator
    {
        private readonly IUnityOfWork _unityOfWork;

        public ProductCreator(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public bool InsertProduct(Product product)
        {
            Category category = GetCategoryByName(product.Category.Name);
            product.CategoryId = category.Id;
            product.QuantityInStock = 0;

            _unityOfWork.Product.Add(product);
            _unityOfWork.Save();

            return true;
        }

        public bool BuyProduct(string name, int quantity)
        {
            Product product = GetProductIdByName(name);
            if (product == null)
            {
                return false;
            }

            _unityOfWork.Product.UpdateQuantityInStock(product);

            return true;
        }

        public bool DeleteProduct(string name)
        {
            if (ManagerLogger.CurrentManager.Role.RoleTitle != "Super Admin")
            {
                throw new Exception("Only Super Admin is allowed");
            }

            Product product = _unityOfWork.Product.GetFirstOrDefault(p => p.Name == name);
            if (product.Id == 0)
            {
                return false;
            }

            _unityOfWork.Product.Remove(product);
            _unityOfWork.Save();

            return true;
        }

        private Product GetProductIdByName(string name)
        {
            IEnumerable<Product> products = _unityOfWork.Product.GetAll();


            foreach (var product in products)
            {
                if (product.Name == name)
                {
                    return product;
                }
            }

            return null;
        }

        private Category GetCategoryByName(string name)
        {
            Category registeredCategories = _unityOfWork.Category.GetFirstOrDefault(
                c => c.Name == name);

            if (registeredCategories != null)
            {
                return registeredCategories;
            }

            throw new Exception();
        }
    }
}
