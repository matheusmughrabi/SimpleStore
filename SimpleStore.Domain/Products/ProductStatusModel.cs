using SimpleStore.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products
{
    public class ProductStatusModel : BaseModel
    {
        public string Status { get; set; }
    }
}
