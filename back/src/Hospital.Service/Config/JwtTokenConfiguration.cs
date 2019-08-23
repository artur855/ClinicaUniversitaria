
using System;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Service.Config
{
    public class JwtTokenConfiguration
    {
        
        public string Audience { get; }
        public string Issuer { get; }  
        public string Key{ get; }
        public DateTime IssuedAt => DateTime.UtcNow;
        public DateTime NotBefore => IssuedAt;

        public SymmetricSecurityKey SymmetricSecurityKey;
        
        public JwtTokenConfiguration(IConfiguration configuration)
        {
            Issuer = configuration["JwtTokenConfiguration:Issuer"];
            Audience = configuration["JwtTokenConfiguration:Audience"];
            Key = configuration["JwtTokenConfiguration:Key"];
            SymmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}