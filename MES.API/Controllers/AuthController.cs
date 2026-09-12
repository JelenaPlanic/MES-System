using MES.Application.Features.Auth;
using MES.Domain.Entities;
using MES.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<User> _userMagager;
        private readonly ITokenService _tokenService;

        public AuthController(UserManager<User> userManager, ITokenService tokenService)
        {
            _userMagager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto registerDto)
        {
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FullName = registerDto.FullName,
                Role = registerDto.Role,
            };

            var result = await _userMagager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join("; ", result.Errors.Select(e => e.Description));
                return BadRequest(errors);
            }

            return Ok(new {message = "Registracija uspesna. Prijavite se."});
           
        }
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponseDto>> Login(LoginDto loginDto)
        {
            var user = await _userMagager.FindByEmailAsync(loginDto.Email);

            if(user is null)
            {
                return Unauthorized("Pogresan email ili lozinka.");
            }

            var isPasswordValid = await _userMagager.CheckPasswordAsync(user, loginDto.Password);

            if (!isPasswordValid)
            {
                return Unauthorized("Pogresna email ili lozinka.");
            }

            var token = _tokenService.GenerateToken(user);

            return Ok(new AuthResponseDto
            {
                Token = token, Email = user.Email, FullName = user.FullName, Role = user.Role.ToString()
            });
        }
    }
}
