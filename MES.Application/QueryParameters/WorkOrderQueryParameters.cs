
using MES.Domain.Entities;

namespace MES.Application.QueryParameters
{
    public class WorkOrderQueryParameters // svaki filter je opcion - nullable
    {
        public WorkOrderStatus? Status { get; set; }
        public int? MachineId { get; set; }
        public int? ProductId { get; set; }
        public DateTime? FromDate {  get; set; } // filter po PlannedStart
        public DateTime? ToDate {  get; set; }
    }
}
