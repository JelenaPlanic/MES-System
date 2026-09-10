using System.ComponentModel.DataAnnotations;

namespace MES.Application.DTOs;

public class CreateWorkOrderDto
{
    [Required(ErrorMessage = "Broj naloga je obavezan.")]
    [MaxLength(50, ErrorMessage = "Broj naloga ne sme biti duzi od 50 karaktera.")]
    public string OrderNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "Proizvod je obavezan.")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Masina je obavezna.")]
    public int MachineId { get; set; }

    [Required(ErrorMessage = "Zaduzeni korisnik je obavezan.")]
    public int AssignedUserId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Planirana kolicina mora biti veca od nule.")]
    public int PlannedQuantity { get; set; }

    [Required(ErrorMessage = "Planirani pocetak je obavezan.")]
    public DateTime PlannedStart { get; set; }

    [Required(ErrorMessage = "Planirani kraj je obavezan.")]
    public DateTime PlannedEnd { get; set; }
} // dodati i za update, ovo je planned nalog
