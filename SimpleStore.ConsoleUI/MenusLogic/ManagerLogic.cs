﻿using SimpleStore.Domain.Manager.ManagerOperations;
using SimpleStore.Domain.Products;
using SimpleStore.Domain.Products.Interfaces;
using SimpleStore.Models.Models;
using System;
using System.Collections.Generic;

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
            Category category = new Category();
            category.Name = inputs[0];

            bool success = _categoryOperator.InsertCategory(category);

            if (success == false)
            {
                Console.WriteLine("Category name cannot be null or already exist");
            }
            else
            {
                Console.WriteLine("Category added successfuly");
            }


            Console.ReadLine();
            return success;
        }

        public bool DeleteCategory(List<string> inputs)
        {
            bool isDeletionSuccess = _categoryOperator.DeleteCategory(inputs[0]);
            if (isDeletionSuccess == true)
            {
                Console.WriteLine($"{inputs[0] } has been deleted");
            }
            else
            {
                Console.WriteLine("Deletion failed");
            }

            Console.ReadLine();
            return isDeletionSuccess;
        }

        public bool InsertProduct(List<string> inputs)
        {
            bool isRegularPriceValid = decimal.TryParse(inputs[3], out decimal regularPrice);
            bool isDiscountedPriceValid = decimal.TryParse(inputs[4], out decimal discountedPrice);

            if (isRegularPriceValid == false || isDiscountedPriceValid == false)
            {
                Console.WriteLine("Invalid Input");
                Console.ReadLine();
                return false;
            }

            Product product = new Product();
            product.Category = new Category();

            product.Name = inputs[0];
            product.Brand = inputs[1];
            product.Category.Name = inputs[2];
            product.RegularPrice = regularPrice;
            product.DiscountedPrice = discountedPrice;
            product.Description = inputs[5];

            _productsOperator.InsertProduct(product);

            return true;
        }

        public bool BuyProduct(List<string> inputs)
        {
            bool isQuantityValid = uint.TryParse(inputs[1], out uint quantity);

            if (isQuantityValid == false || quantity == 0)
            {
                Console.WriteLine("Invalid Amount");
                Console.ReadLine();
                return false;
            }

            bool isPurchaseSuccessful = _productsOperator.BuyProduct(inputs[0], (int)quantity);

            if (isPurchaseSuccessful)
            {
                Console.WriteLine($"You bought { inputs[1] } units of {inputs[0]}");
            }
            else
            {
                Console.WriteLine("Purchase failed");
            }

            Console.ReadLine();
            return isPurchaseSuccessful;
        }

        public bool DeleteProduct(List<string> inputs)
        {
            bool isDeletionSuccess = _productsOperator.DeleteProduct(inputs[0]);
            if (isDeletionSuccess == true)
            {
                Console.WriteLine($"{inputs[0] } has been deleted");
            }
            else
            {
                Console.WriteLine("Deletion failed");
            }

            Console.ReadLine();
            return isDeletionSuccess;
        }
    }
}
