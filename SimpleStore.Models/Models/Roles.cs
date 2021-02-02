using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Roles : BaseModel
    {
        [Required]
        public string RoleTitle { get; set; }
    }
}
