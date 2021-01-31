using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleStore.Models.Models.Base
{
    public class DateTrackedModel : BaseModel
    {
        [Required]
        [Display(Name = "Inserted At")]
        public DateTime InsertedAt { get; set; }

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; }
    }
}
