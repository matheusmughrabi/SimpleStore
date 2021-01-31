using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class ManagerAccount : BaseModel
    {
        [Required]
        [Display(Name = "Account Owner")]
        public int AccountOwnerId { get; set; }

        [ForeignKey(nameof(AccountOwnerId))]
        public virtual AccountOwner AccountOwner { get; set; }

        [Required]
        [Display(Name = "Manager Permission")]
        public int ManagerPermissionId { get; set; }

        [ForeignKey(nameof(ManagerPermissionId))]
        public virtual ManagerPermission ManagerPermission { get; set; }

        public ManagerAccount()
        {

        }
        public ManagerAccount(AccountOwner accountOwner)
        {
            AccountOwner = accountOwner;
        }
    }
}
