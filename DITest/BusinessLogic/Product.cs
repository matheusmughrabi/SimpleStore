using System;
using System.Collections.Generic;
using System.Text;

namespace DITest.BusinessLogic
{
    public class Product
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
