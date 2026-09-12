using MES.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MES.Infrastructure.Auth
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Ime i prezime su obavezni.")]
        [MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email je obavezan.")]
        [EmailAddress(ErrorMessage = "Email nije u ispravnom formatu.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [MinLength(6, ErrorMessage = "Lozinka mora imati bar 6 karaktera.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Uloga je obavezna.")]
        public UserRole Role { get; set; }
    }
}
