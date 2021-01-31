using SimpleStore.Models.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Models
{
    public class Manager : BaseModel
    {
        public int Id { get; set; }
        public AccountOwner AccountOwner { get; set; }
        public ManagerPermission ManagerPermission { get; set; }
    }
}
