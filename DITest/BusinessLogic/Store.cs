using System;
using System.Collections.Generic;
using System.Text;

namespace DITest.BusinessLogic
{
    public class Store
    {
        public Product Product { get; set; }

        public Store(Product product)
        {
            Product = product;
        }

        public void TellsProductName()
        {
            Console.WriteLine(Product.Name);
        }
    }
}
