using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // app-level-default
        public DateTime? UpdatedAt { get; set; } // null
    }
}
