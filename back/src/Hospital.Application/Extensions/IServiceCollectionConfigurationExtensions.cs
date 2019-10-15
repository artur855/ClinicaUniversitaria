using System;
using System.IO;
using System.Reflection;
using System.Text;
using Hospital.Service.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using Hospital.Domain.Mapping;

namespace Hospital.Application.Extensions
{
    public static class IServiceCollectionConfigurationExtensions
    {
        public static IServiceCollection AddJwtTokenConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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
            
            services.AddScoped<JwtTokenConfiguration>();
            return services;
        }

        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("ClinicaUniversitaria", new Info
                {
                    Title = "Clinica Universitaria",
                    Version = "V1"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
                
            });
            return services;
        }

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var mappingConfiguration = new MapperConfiguration(mc => 
            {
                mc.AddProfile(new ModelToDTOProfile());
                mc.AddProfile(new ModelToCommandProfile());
            });

            IMapper mapper = mappingConfiguration.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }

    }
}