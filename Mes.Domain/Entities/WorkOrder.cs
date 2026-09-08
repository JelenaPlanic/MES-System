using MES.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace MES.Domain.Entities
{
    public enum WorkOrderStatus
    {
        Planned,
        InProgress,
        Completed,
        Cancelled
    }
    public class WorkOrder : BaseEntity
    {
        public string OrderNumber { get; set; } = string.Empty; // sifra naloga

        public int ProductId { get; set; } // FK
        public Product Product { get; set; } = null!; // ceo product, nece biti null u runtime, prestani da me upozoravas.

        public int MachineId { get; set; }
        public Machine Machine { get; set; } = null!;

        public int AssignedUserId { get; set; }
        public User AssignedUser { get; set; } = null!;

        public int PlannedQuantity { get; set; }
        public int ProducedQuantity { get; set; }

        public DateTime PlannedStart { get; set; }
        public DateTime PlannedEnd { get; set; }
        public DateTime? ActualStart { get; set; } // dok nalog ne pocne, on je null.
        public DateTime? ActualEnd { get; set; }

        public WorkOrderStatus Status { get; set; } // zivotni ciklus naloga

        public ICollection<Downtime> DownTimes { get; set; } = new List<Downtime>(); // zastoji
        public ICollection<Defect> Defects { get; set; } = new List<Defect>(); // defekti
    }
}
