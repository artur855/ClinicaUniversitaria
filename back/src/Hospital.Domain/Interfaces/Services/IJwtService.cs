using System.Security.Claims;
using System.Threading.Tasks;
using Hospital.Domain.DTO;
using Hospital.Domain.Entities;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IJwtService
    {
        JwtTokenDTO CreateJwtToken(User user);
        ClaimsIdentity GetClaimsIdentity(User user);
    }
}