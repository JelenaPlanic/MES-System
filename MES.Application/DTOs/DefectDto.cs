namespace MES.Application.DTOs;

public class DefectDto
{
    public int Id { get; set; }

    public int WorkOrderId { get; set; }
    public string WorkOrderNumber { get; set; } = string.Empty;

    public int DefectTypeId { get; set; }
    public string DefectTypeDescription { get; set; } = string.Empty;

    public int Quantity { get; set; }
    public DateTime DetectedAt { get; set; }
    public string? Notes { get; set; }
}
