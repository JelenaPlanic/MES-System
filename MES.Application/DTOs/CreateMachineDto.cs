using System.ComponentModel.DataAnnotations;
using MES.Domain.Entities;

namespace MES.Application.DTOs;

public class CreateMachineDto
{
    [Required(ErrorMessage = "Sifra masine je obavezna.")]
    [MaxLength(50, ErrorMessage = "Sifra ne sme biti duza od 50 karaktera.")]
    public string Code { get; set; } = string.Empty;

    [Required(ErrorMessage = "Naziv masine je obavezan.")]
    [MaxLength(200, ErrorMessage = "Naziv ne sme biti duzi od 200 karaktera.")]
    public string Name { get; set; } = string.Empty;

    public MachineStatus Status { get; set; }
}