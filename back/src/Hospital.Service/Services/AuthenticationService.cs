using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Hospital.Domain.DTO;
using Hospital.Domain.Interfaces.Repositories;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Config;
using Microsoft.IdentityModel.Tokens;

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
        
        public async Task<JwtTokenDTO> Authenticate(LoginDTO loginDto)
        {
            var user = await _userRepository.Authenticate(loginDto.Email, loginDto.Password);
            if (user == null)
                return null;
            
            var token = _jwtService.CreateJwtToken(user);
            
            return token;
        }
    }
}