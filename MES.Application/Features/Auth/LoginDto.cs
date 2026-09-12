using System.ComponentModel.DataAnnotations;

namespace MES.Infrastructure.Auth
{
    public class LoginDto
    {

        [Required(ErrorMessage = "Email je obavezan.")]
        [EmailAddress(ErrorMessage = "Email nije u ispravnom formatu.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Lozinka je obavezna.")]
        [MinLength(6, ErrorMessage = "Lozinka mora imati bar 6 karaktera.")]
        public string Password { get; set; } = string.Empty;
    }
}
