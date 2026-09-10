using System.ComponentModel.DataAnnotations;

namespace MES.Application.DTOs;

public class CreateDowntimeDto
{
    [Required(ErrorMessage = "Radni nalog je obavezan.")]
    public int WorkOrderId { get; set; }

    [Required(ErrorMessage = "Razlog zastoja je obavezan.")]
    public int DowntimeReasonId { get; set; }

    [Required(ErrorMessage = "Vreme pocetka je obavezno.")]
    public DateTime StartTime { get; set; }

    public DateTime? EndTime { get; set; }

    [MaxLength(500, ErrorMessage = "Napomena ne sme biti duza od 500 karaktera.")]
    public string? Notes { get; set; }
}
