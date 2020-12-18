using SimpleStore.Domain.Products.Categories;
using SimpleStore.Domain.Products.ProductsModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.ConsoleUI.Control.BeardStore
{
    public class BeardStoreProducts
    {
        private CategoryModel _category;

        public BeardStoreProducts(CategoryModel category)
        {
            _category = category;
        }


    }
}
