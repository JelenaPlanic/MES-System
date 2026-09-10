namespace MES.Application.DTOs;

public class DowntimeDto
{
    public int Id { get; set; }

    public int WorkOrderId { get; set; }
    public string WorkOrderNumber { get; set; } = string.Empty;

    public int DowntimeReasonId { get; set; }
    public string DowntimeReasonDescription { get; set; } = string.Empty;

    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public string? Notes { get; set; }
}
