
using System.ComponentModel.DataAnnotations;

namespace MES.Application.DTOs
{
   public class CreateProductDto // kontejner podataka
   {
        [Required(ErrorMessage = "Sifra proizvoda je obavezna.")]
        [MaxLength(50, ErrorMessage = "Sifra ne sme biti duza od 50 karaktera.")]
        public string Code { get; set; } = string.Empty; // default vrednost u C#-u, // — sprečava da property slučajno bude null ako ga niko ne postavi.

        [Required(ErrorMessage = "Naziv proizvoda je obavezan.")]
        [MaxLength(200, ErrorMessage = "Naziv ne sme biti duzi od 200 karaktera.")]
        public string Name { get; set; } = string.Empty;

        [Range(0.1, double.MaxValue, ErrorMessage = "Vreme izrade mora biti vece od nule.")]
        public double CycleTimeSeconds { get; set; }
   }
    // sa validacijom : Data anotacije na DTO Klasama, ili FluentValidation biblioteka
}
