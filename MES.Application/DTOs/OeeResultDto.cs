namespace MES.Application.DTOs;

public class OeeResultDto
{
    public int WorkOrderId { get; set; }
    public string OrderNumber { get; set; } = string.Empty;

    public double Availability { get; set; }
    public double Performance { get; set; }
    public double Quality { get; set; }
    public double Oee { get; set; }
}
