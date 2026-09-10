using System.ComponentModel.DataAnnotations;

namespace MES.Application.DTOs;

public class CreateShiftDto
{
    [Required(ErrorMessage = "Naziv smene je obavezan.")]
    [MaxLength(50, ErrorMessage = "Naziv ne sme biti duzi od 50 karaktera.")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Vreme pocetka smene je obavezno.")] // "HH:mm:ss"
    public TimeSpan StartTime { get; set; }

    [Required(ErrorMessage = "Vreme kraja smene je obavezno.")] //"HH:mm:ss"
    public TimeSpan EndTime { get; set; }
}
