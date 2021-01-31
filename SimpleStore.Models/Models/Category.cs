using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Category : DateTrackedModel
    {
        [Required]
        public string Name { get; set; }

        [Display(Name = "Parent Category")]
        public int? ParentCategoryId { get; set; }
    }
}
