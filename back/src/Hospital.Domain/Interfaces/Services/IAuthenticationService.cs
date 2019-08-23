using System.Threading.Tasks;
using Hospital.Domain.DTO;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<JwtTokenDTO> Authenticate(LoginDTO loginDto);
    }
}