using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Product : DateTrackedModel
    {
        [Required]
        public string Name { get; set; }

        [Required]      
        public string Brand { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    
        [ForeignKey(nameof(CategoryId))]
        public virtual Category Category { get; set; }

        [Display(Name = "Regular Price")]
        public decimal RegularPrice { get; set; }

        [Display(Name = "Discounted Price")]
        public decimal DiscountedPrice { get; set; }

        public string Description { get; set; }

        [Display(Name = "Quantity in Stock")]
        public int QuantityInStock { get; set; }
    }
}
