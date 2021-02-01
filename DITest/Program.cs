using DITest.BusinessLogic;
using System;

namespace DITest
{
    class Program
    {
        static void Main(string[] args)
        {
            Store Store = new Store(new Product("shaver"));

            Store.TellsProductName();
        }
    }
}
