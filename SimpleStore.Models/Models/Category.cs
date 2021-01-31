using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Category : DateTrackedModel
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
