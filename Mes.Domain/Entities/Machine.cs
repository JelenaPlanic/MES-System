using MES.Domain.Common;

namespace MES.Domain.Entities
{
    public enum MachineStatus
    {
        Available,
        InUse,
        UnderMaintenance,
        OutOfOrder
    }
    public class Machine : BaseEntity
    {
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public MachineStatus Status { get; set; } // EF CUVA ENUM U BAZI KAO int
        public ICollection<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
