
using MES.Domain.Entities;

namespace MES.Application.Features.Auth
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
