using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleStore.Models.Models.Base
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
    }
}
