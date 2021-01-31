using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Account : DateTrackedModel
    {

        [Required]
        [Display(Name = "Account Owner")]
        public int AccountOwnerId { get; set; }

        [ForeignKey(nameof(AccountOwnerId))]
        public virtual AccountOwner AccountOwner { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public Account()
        {

        }

        public Account(AccountOwner accountOwner)
        {
            AccountOwner = accountOwner;
        }       
    }
}
