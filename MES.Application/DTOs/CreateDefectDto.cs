using System.ComponentModel.DataAnnotations;

namespace MES.Application.DTOs;

public class CreateDefectDto
{
    [Required(ErrorMessage = "Radni nalog je obavezan.")]
    public int WorkOrderId { get; set; }

    [Required(ErrorMessage = "Tip defekta je obavezan.")]
    public int DefectTypeId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Kolicina mora biti veca od nule.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "Vreme evidentiranja je obavezno.")]
    public DateTime DetectedAt { get; set; }

    [MaxLength(500, ErrorMessage = "Napomena ne sme biti duza od 500 karaktera.")]
    public string? Notes { get; set; }
}
