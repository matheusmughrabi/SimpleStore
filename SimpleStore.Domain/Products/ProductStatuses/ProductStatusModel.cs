using SimpleStore.Domain.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.Products.ProductStatuses
{
    public class ProductStatusModel : BaseModel
    {
        public string Status { get; set; }
    }
}
