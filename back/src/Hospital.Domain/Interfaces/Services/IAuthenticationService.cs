using Hospital.Domain.Entities;
using System.Threading.Tasks;

namespace Hospital.Domain.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<string> Authenticate(User user);
    }
}