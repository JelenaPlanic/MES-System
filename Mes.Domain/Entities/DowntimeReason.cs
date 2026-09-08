using MES.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entities
{
    public class DowntimeReason : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<Downtime> Downtimes { get; set; } = new List<Downtime>();
    }
}
