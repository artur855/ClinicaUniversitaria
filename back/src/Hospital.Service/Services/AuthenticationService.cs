using System.Threading.Tasks;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;

namespace Hospital.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;
        public AuthenticationService(IUserRepository userRepository, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }
        
        public async Task<string> Authenticate(User user)
        {
            var loggedUser = await _userRepository.Authenticate(user.Email, user.Password);
            if (loggedUser == null)
                return null;
               
            var token = _jwtService.CreateJwtToken(loggedUser);
            
            return token;
        }

    }
}