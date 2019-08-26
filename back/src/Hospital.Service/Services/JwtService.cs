using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using Hospital.Domain.DTO;
using Hospital.Domain.Entities;
using Hospital.Domain.Interfaces.Services;
using Hospital.Service.Config;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Service.Services
{
    public class JwtService : IJwtService
    {
        private readonly JwtTokenConfiguration _jwtTokenConfiguration;

        public JwtService(JwtTokenConfiguration jwtTokenConfiguration)
        {
            _jwtTokenConfiguration = jwtTokenConfiguration;
        }
        public JwtTokenDTO CreateJwtToken(User user)
        {
            var identity = GetClaimsIdentity(user);
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Subject = identity,
                Issuer = _jwtTokenConfiguration.Issuer,
                Audience = _jwtTokenConfiguration.Audience,
                IssuedAt = _jwtTokenConfiguration.IssuedAt,
                NotBefore = _jwtTokenConfiguration.NotBefore,
                SigningCredentials = new SigningCredentials(_jwtTokenConfiguration.SymmetricSecurityKey, SecurityAlgorithms.HmacSha256)
            });

            var jwtToken = handler.WriteToken(securityToken);
            return new JwtTokenDTO()
            {
                Token = jwtToken
            };
        }

        public ClaimsIdentity GetClaimsIdentity(User user)
        {
            return new ClaimsIdentity
            (
                new GenericIdentity(user.Id.ToString()),
                new[] {
                    new Claim(
                        JwtRegisteredClaimNames.NameId, user.Id.ToString()
                    )
                }
            );
        }
    }
}