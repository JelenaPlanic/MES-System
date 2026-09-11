using System.ComponentModel.DataAnnotations;
using MES.Domain.Entities;

namespace MES.Application.DTOs;

public class UpdateWorkOrderDto
{
    [Required]
    public WorkOrderStatus Status { get; set; }

    public int ProducedQuantity { get; set; }

    public DateTime? ActualStart { get; set; } // mogu se slati prazni dok nalog nije poceo / zavrsen

    public DateTime? ActualEnd { get; set; }
}
