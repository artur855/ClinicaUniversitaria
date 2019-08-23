using System.Text;
using Hospital.Service.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Hospital.Application.Extensions
{
    public static class IServiceCollectionConfigurationExtensions
    {
        public static IServiceCollection AddJwtTokenConfiguration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                      options.TokenValidationParameters = new TokenValidationParameters
                      {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["JwtTokenConfiguration:Issuer"],
                        ValidAudience = configuration["JwtTokenConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtTokenConfiguration:Key"]))
                      };
                    });

            serviceCollection.AddScoped<JwtTokenConfiguration>();
            return serviceCollection;
        }
    }
}