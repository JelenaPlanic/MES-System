using MES.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public double CycleTimeSeconds { get; set; }

        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
