using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Domain.BaseModels
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime InsertedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
