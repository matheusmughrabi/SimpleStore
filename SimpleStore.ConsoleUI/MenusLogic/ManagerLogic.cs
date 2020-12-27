using SimpleStore.Domain.Manager.ManagerOperations;
using SimpleStore.Domain.Products;
using SimpleStore.Domain.Services.ProductsServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.MenusLogic
{
    public class ManagerLogic
    {
        private readonly ICategoryOperator _categoryOperator;
        private readonly IProductsOperator _productsOperator;

        public ManagerLogic(ICategoryOperator categoryOperator, IProductsOperator productsOperator)
        {
            _categoryOperator = categoryOperator;
            _productsOperator = productsOperator;
        }

        public bool InsertCategory(List<string> inputs)
        {
            CategoryModel category = new CategoryModel();
            category.CategoryName = inputs[0];

            bool success = _categoryOperator.InsertCategory(category);

            if (success == false)
            {
                Console.WriteLine("This category already exists");
                Console.ReadLine();
                return false;
            }

            return true;
        }

        public bool InsertProduct(List<string> inputs)
        {
            ProductModel product = new ProductModel();
            product.Category = new CategoryModel();

            product.Name = inputs[0];
            product.Brand = inputs[1];
            product.Category.CategoryName = inputs[2];
            product.RegularPrice = decimal.Parse(inputs[3]);
            product.DiscountedPrice = decimal.Parse(inputs[4]);
            product.Description = inputs[5];
            //product.ProductStatus.Status = inputs[6];

            _productsOperator.InsertProduct(product);

            return true;
        }
    }
}
