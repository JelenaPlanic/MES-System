using MES.Domain.Entities;

namespace MES.Application.DTOs;

public class WorkOrderDto
{
    public int Id { get; set; }
    public string OrderNumber { get; set; } = string.Empty;

    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;

    public int MachineId { get; set; }
    public string MachineName { get; set; } = string.Empty;

    public int AssignedUserId { get; set; }
    public string AssignedUserName { get; set; } = string.Empty;

    public int PlannedQuantity { get; set; }
    public int ProducedQuantity { get; set; }
    public DateTime PlannedStart { get; set; }
    public DateTime PlannedEnd { get; set; }
    public DateTime? ActualStart { get; set; }
    public DateTime? ActualEnd { get; set; }
    public WorkOrderStatus Status { get; set; }
}
