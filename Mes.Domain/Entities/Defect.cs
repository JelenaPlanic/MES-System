using MES.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entities
{
    public class Defect : BaseEntity
    {
        public int WorkOrderId { get; set; } // FK
        public WorkOrder WorkOrder { get; set; } = null!;

        public int DefectTypeId { get; set; }
        public DefectType DefectType { get; set; } = null!;

        public int Quanity { get; set; } // koliko komada skartova
        public DateTime DetectedAt { get; set; } // evidencija defekta

        public string? Notes { get; set; } // opciona napomena
    }
}
