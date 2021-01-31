using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleStore.Models.Models.Base
{
    public class DateTrackedModel : BaseModel
    {
        public DateTime InsertedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
