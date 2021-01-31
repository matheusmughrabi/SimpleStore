using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class ManagerPermission : BaseModel
    {
        [Required]
        public string PermissionTitle { get; set; }
    }
}
