using System.ComponentModel.DataAnnotations;

namespace MES.Application.DTOs
{
    public class CreateDefectTypeDto
    {
        [Required(ErrorMessage = "Sifra tipa defekta je obavezna.")]
        [MaxLength(20, ErrorMessage = "Sifra ne sme biti duza od 20 karaktera.")]
        public string Code { get; set; } = string.Empty;

        [Required(ErrorMessage = "Opis tipa defekta je obavezan.")]
        [MaxLength(200, ErrorMessage = "Opis ne sme biti duzi od 200 karaktera.")]
        public string Description { get; set; } = string.Empty;
    }
}
